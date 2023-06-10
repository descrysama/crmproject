using Microsoft.AspNetCore.Mvc;
using BluePillCRM.Business.Services;
using BluePillCRM.Business.Dtos;
using BluePillCRM.Datas.Entities;
using BluePillCRM.Application.WebApi.Utilities;
using BluePillCRM.Business.Services.Utilities;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Api.OnlineShop.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly UserService _userService;

    private readonly CrmConfigService _crmConfigService;

    private readonly IConfiguration _configuration;

    public UserController(UserService userService, CrmConfigService crmConfigService, IConfiguration configuration)
    {
        _userService = userService;
        _crmConfigService = crmConfigService;
        _configuration = configuration;
    }

    [Authorize]
    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(createUser createUser)
    {
        try
        {
            int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            User checkUserRole = await _userService.FindOneById(userId);
            bool IsAllowedToCreate = await _crmConfigService.IsAllowedToCreateUser();
            if (checkUserRole.RoleId > 1 || checkUserRole.RoleId > 3 || !IsAllowedToCreate) 
            {
                return StatusCode(500, new { message = "Vous ne pouvez pas créer d'utilisateur supplémentaires. Veuillez consulter l'administrateur CRM." });
            }

            User createdUser = await _userService.CreateUser(createUser).ConfigureAwait(false);

            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(2),
                Path = "/",
                Secure = true,
                SameSite = SameSiteMode.Strict
            };

            Response.Cookies.Append("_auth", JwtGenerator.GenerateJwtToken(createdUser.Id.ToString(), createdUser.Email, _configuration), cookieOptions);

            return Ok(UserEntityToDto.ReadUserMapper(createdUser));
        } catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpPost("signin")]
    public async Task<IActionResult> Signin(SignInUser signInUser)
    {
        try
        {
            User user = await _userService.FindOneByEmail(signInUser.Email.ToString()).ConfigureAwait(false);
            if(user == null)
            {
                return StatusCode(500, new { message = "Email et/ou password incorrects" });
            }

            bool checkIfPasswordMatch = PasswordHandler.VerifyPassword(signInUser.Password, user.Password);
            if (checkIfPasswordMatch)
            {
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddDays(2),
                    Path = "/",
                    Secure = true,
                    SameSite = SameSiteMode.Strict
                };

                Response.Cookies.Append("_auth", JwtGenerator.GenerateJwtToken(user.Id.ToString(), user.Email, _configuration), cookieOptions);
                return Ok(UserEntityToDto.ReadUserMapper(user));
            } else
            {
                return StatusCode(500, new { message = "Email et/ou password incorrects" });
            }

        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
