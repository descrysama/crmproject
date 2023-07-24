using Microsoft.AspNetCore.Mvc;
using BluePillCRM.Business.Services;
using BluePillCRM.Business.Dtos;
using BluePillCRM.Datas.Entities;
using BluePillCRM.Business.Services.Utilities;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace BluePillCRM.Application.WebApi.Controllers
{
    [ApiController]
    [Route("address")]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;
        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [Authorize]
        [HttpGet("getsingle/{Id}")]
        public async Task<IActionResult> GetAddress([FromRoute] int Id)
        {
            if (Id == 0)
            {
                return BadRequest("Veuillez choisir une addresse.");
            }

            int userRole = Int32.Parse(User.FindFirst("Role")?.Value);

            try
            {
                Address address = await _addressService.GetAddress(Id, userRole).ConfigureAwait(false);
                return Ok(AddressEntityToDto.ReadAddressMapper(address));
            } catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPost()]
        public async Task<IActionResult> CreateAddress(createAddress createAddress)
        {
            int userRole = Int32.Parse(User.FindFirst("Role")?.Value);

            if (createAddress == null)
            {
                return BadRequest("Veuillez remplir au moins un champs.");
            }

            if(createAddress.AccessLevel < userRole)
            {
                return BadRequest("Impossible d'ajouter une adresse avec un niveau d'accès supérieur au votre.");
            }

            try
            {
                Address address = await _addressService.CreateAddress(createAddress).ConfigureAwait(false);
                return Ok(address);
            } catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPatch()]
        public async Task<IActionResult> UpdateAddress(updateAddress updateAddress)
        {
            int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            int userRole = Int32.Parse(User.FindFirst("Role")?.Value);

            if (updateAddress.Id == 0)
            {
                return BadRequest("Veuillez indiquer une addresse à modifier.");
            }
            
            if(updateAddress.AccessLevel < userRole)
            {
                updateAddress.AccessLevel = userRole;
            }


            try
            {
                Address address = await _addressService.UpdateAddress(updateAddress, userId).ConfigureAwait(false);
                return Ok(address);
            } catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> DeleteAddress([FromRoute] int Id)
        {
            if(Id == 0)
            {
                return StatusCode(500, "Veuillez saisir une addresse à supprimer.");
            }
            int userRole = Int32.Parse(User.FindFirst("Role")?.Value);

            try
            {
                Address deleteAddress = await _addressService.DeleteAddress(Id, userRole).ConfigureAwait(false);
                if(deleteAddress == null)
                {
                    return BadRequest("Une erreur s'est produite.");
                } else
                {
                    return Ok("Adresse supprimée.");
                }
            } catch(Exception ex)
            {
                return StatusCode(500, new {message = ex.Message});
            }

        }

    }
}
