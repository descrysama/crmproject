using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BluePillCRM.Business.Services;
using BluePillCRM.Datas.Entities;

namespace Api.OnlineShop.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly AddressService _addressService;

    private readonly IConfiguration _configuration;

    public UserController(AddressService addressService, IConfiguration configuration)
    {
        _addressService = addressService;
        _configuration = configuration;
    }

}
