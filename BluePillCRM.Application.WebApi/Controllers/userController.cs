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
[Route("user")]
public class UserController : ControllerBase
{

    private readonly UserService _userService;

    private readonly UserUtilities _userUtilities;

    private readonly CrmConfigService _crmConfigService;

    private readonly IConfiguration _configuration;

    public UserController(UserService userService, CrmConfigService crmConfigService, UserUtilities userUtilities, IConfiguration configuration)
    {
        _userUtilities = userUtilities;
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
            int userRole = Int32.Parse(User.FindFirst(ClaimTypes.Role)?.Value);
            bool IsAllowedToCreate = await _crmConfigService.IsAllowedToCreateUser();
            if (userRole > 3 && userRole != 1 || !IsAllowedToCreate && userRole != 1) 
            {
                return StatusCode(500, new { message = "Vous ne pouvez pas créer d'utilisateur supplémentaires. Veuillez consulter l'administrateur CRM." });
            }

            if(createUser.RoleId == 1) 
            {
                return StatusCode(500, new { message = "Modifier le role de l'utilisateur." });
            }

            User createdUser = await _userService.CreateUser(createUser).ConfigureAwait(false);

            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(2),
                Path = "/",
                Secure = true,
                SameSite = SameSiteMode.Strict
            };

            //Response.Cookies.Append("_auth", JwtGenerator.GenerateJwtToken(createdUser.Id.ToString(), createdUser.Email, createdUser.RoleId.ToString(), createdUser.RoleId, _configuration), cookieOptions);

            return Ok(UserEntityToDto.ReadUserMapper(createdUser));
        } catch (Exception ex)
        {
            return StatusCode(500, new { message = ex });
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
                return StatusCode(500, new { message = "Email et/ou password incorrect(s)" });
            }
            if(user.IsDisabled == true)
            {
                return StatusCode(500, new { message = "Votre compte a été desactivé. Veuillez contacter votre supérieur." });
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

                Response.Cookies.Append("_auth", JwtGenerator.GenerateJwtToken(user.Id.ToString(), user.Email, user.RoleId, _configuration), cookieOptions);
                return Ok(UserEntityToDto.ReadUserMapper(user));
            } else
            {
                return StatusCode(500, new { message = "Email et/ou password incorrect(s) " });
            }

        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [Authorize]
    [HttpPatch()]
    public async Task<IActionResult> Update(UpdateUser updateUser)
    {
        int userRole = Int32.Parse(User.FindFirst(ClaimTypes.Role)?.Value);
        int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        User targetUserExists = await _userService.FindOneById(updateUser.Id);

        if (targetUserExists != null)
        {
            if (userRole < targetUserExists.RoleId || userId == updateUser.Id)
            {
                return Ok(await _userService.UpdateUser(updateUser));
            } else
            {
                return BadRequest("Vous ne pouvez pas mettre à jour cet utilisateur. Vous outrepassez vos autorisations.");
            }
            
        } else 
        { 
            return BadRequest("L'utilisteur n'existe pas."); 
        }
    }

    [Authorize()]
    [HttpPost("disable/{id}")]
    public async Task<IActionResult> Disable([FromRoute] int id)
    {
        int userRole = Int32.Parse(User.FindFirst(ClaimTypes.Role)?.Value);
        int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        User userToDisable = await _userService.FindOneById(id).ConfigureAwait(false);

        if (userToDisable == null)
        {
            return BadRequest("Utilisateur non trouvé.");
        }

        if(userToDisable.RoleId < userRole)
        {
            return BadRequest("Vous ne pouvez pas desactiver un compte ayant un niveau d'accès suppérieur à vous.");
        }

        if(userRole == userToDisable.RoleId || userToDisable.Id != userId)
        {
            return BadRequest("Vous ne pouvez pas supprimer un compte ayant les mêmes droits que vous.");
        }

        try
        {
            User disabledUser = await _userService.DisableUser(id, userRole);

            if (disabledUser != null)
            {
                return Ok(disabledUser);
            }
            return BadRequest("L'utilisateur n'a pas pu être desactiver.");

        } catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
