using BluePillCRM.Datas.Entities;
using BluePillCRM.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using BluePillCRM.Business.Dtos;

namespace BluePillCRM.Application.WebApi.Controllers
{
    [ApiController]
    [Route("invoice")]
    public class InvoiceController: ControllerBase
    {

        InvoiceService _invoiceService;

        public InvoiceController(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;

        }

        [Authorize]
        [HttpGet("get/{invoiceId}")]
        public async Task<IActionResult> GetById(int invoiceId)
        {
            int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            int userRole = Int32.Parse(User.FindFirst("Role")?.Value);

            if (invoiceId == 0)
            {
                return BadRequest("Veuillez fournir un id de contact.");
            }

            try
            {
                Invoice singleQuote = await _invoiceService.FindById(invoiceId);
                if (singleQuote != null)
                {
                    return Ok(InvoiceEntityToDto.ReadInvoiceMapper(singleQuote));
                }
                else
                {
                    return Ok(new { message = "Aucun devis trouvé" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}


