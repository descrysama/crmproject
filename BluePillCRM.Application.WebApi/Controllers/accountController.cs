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
[Route("account")]
public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;

    private readonly UserService _userService;

    private readonly UserUtilities _userUtilities;

    private readonly CrmConfigService _crmConfigService;

    private readonly IConfiguration _configuration;

    public AccountController(AccountService accountService, UserService userService, CrmConfigService crmConfigService, UserUtilities userUtilities, IConfiguration configuration)
    {
        _userUtilities = userUtilities;
        _accountService = accountService;
        _userService = userService;
        _crmConfigService = crmConfigService;
        _configuration = configuration;
    }

    [Authorize]
    [HttpPost("createAccount")]
    public async Task<IActionResult> createAccount(createAccount accountCreate)
    {
        try
        {
            Account createdAccount = await _accountService.CreateAccount(accountCreate).ConfigureAwait(false);
            return Ok(AccountEntityToDto.readAccountMapper(createdAccount));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
