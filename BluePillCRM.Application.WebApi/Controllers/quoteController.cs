using Microsoft.AspNetCore.Mvc;
using BluePillCRM.Business.Services;
using BluePillCRM.Business.Dtos;
using BluePillCRM.Datas.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BluePillCRM.Application.WebApi.Controllers
{
    [ApiController]
    [Route("quote")]
    public class QuoteController : ControllerBase
    {
        private readonly QuoteService _quoteService;

        private readonly ProductService _productService;

        private readonly QuoteProductService _quoteProductService;

        private readonly TaxService _taxService;

        public QuoteController(QuoteService quoteService, ProductService productService, QuoteProductService quoteProductService, TaxService taxService)
        {
            _quoteService = quoteService;
            _productService = productService;
            _quoteProductService = quoteProductService;
            _taxService = taxService;
        }

        [Authorize]
        [HttpGet("get/{quoteId}")]
        public async Task<IActionResult> GetQuoteById(int quoteId)
        {
            int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            int userRole = Int32.Parse(User.FindFirst("Role")?.Value);

            if (quoteId == 0)
            {
                return BadRequest("Veuillez fournir un id de contact.");
            }

            try
            {
                Quote singleQuote = await _quoteService.FindById(quoteId);
                if (singleQuote != null)
                {
                    return Ok(QuoteEntityToDto.ReadQuoteMapper(singleQuote));
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

        [Authorize]
        [HttpGet("bycontact")]
        public async Task<IActionResult> GetQuoteByContact(int contactId, Boolean onlyAcceptedQuotes)
        {
            int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            int userRole = Int32.Parse(User.FindFirst("Role")?.Value);

            if(contactId == 0)
            {
                return BadRequest("Veuillez fournir un id de contact.");
            }

            try
            {
                List<Quote> fetchedQuotes = await _quoteService.FindByContact(contactId, onlyAcceptedQuotes);
                if(fetchedQuotes != null)
                {
                    return Ok(fetchedQuotes.Select(singleQuote => QuoteEntityToDto.ReadQuoteMapper(singleQuote)));
                } else
                {
                    return Ok(new { message = "Aucun devis trouvé" });
                }
            } catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }

        [Authorize]
        [HttpGet("byaccount")]
        public async Task<IActionResult> GetQuoteByAccount(int accountId, Boolean onlyAcceptedQuotes)
        {
            int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            int userRole = Int32.Parse(User.FindFirst("Role")?.Value);

            if (accountId == 0)
            {
                return BadRequest("Veuillez fournir un id de contact.");
            }

            try
            {
                List<Quote> fetchedQuotes = await _quoteService.FindByAccount(accountId, onlyAcceptedQuotes);
                if (fetchedQuotes != null)
                {
                    return Ok(fetchedQuotes.Select(singleQuote => QuoteEntityToDto.ReadQuoteMapper(singleQuote)));
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


        [Authorize]
        [HttpPatch("accept")]
        public async Task<IActionResult> Accept(int quoteId)
        {
            int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            int userRole = Int32.Parse(User.FindFirst("Role")?.Value);

            Quote quote = await _quoteService.GetSingle(quoteId);

            if (userRole > quote.AccessLevel)
            {
                return BadRequest("Vous n'avez pas l'autorisation d'effectuer cette actions.");
            }

            quote.UpdatedBy = userId;
            quote.UpdatedAt = DateTime.Now;
            if(quote.QuoteStatus == true)
            {
                return StatusCode(500, new { message = "Ce devis est déjà marqué comme accepté" });
            } else
            {
                quote.QuoteStatus = true;
            }

            try
            {
                await _quoteService.Update(quote);
                return Ok(quote);
            } catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }

        [Authorize]
        [HttpPatch("refuse")]
        public async Task<IActionResult> Refuse(int quoteId)
        {
            int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            int userRole = Int32.Parse(User.FindFirst("Role")?.Value);

            Quote quote = await _quoteService.GetSingle(quoteId);

            if (userRole > quote.AccessLevel)
            {
                return BadRequest("Vous n'avez pas l'autorisation d'effectuer cette actions.");
            }

            quote.UpdatedBy = userId;
            quote.UpdatedAt = DateTime.Now;
            if (quote.QuoteStatus == false)
            {
                return StatusCode(500, new { message = "Ce devis est déjà marqué comme refusé" });
            } else
            {
                quote.QuoteStatus = false;
            }

            try
            {
                await _quoteService.Update(quote);
                return Ok(quote);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }
    }
}
