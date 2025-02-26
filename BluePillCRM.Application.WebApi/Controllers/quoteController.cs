﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpPost()]
        public async Task<IActionResult> CreateQuote(CreateQuote createQuote)
        {
            List<QuotesProduct> quoteProductList = new List<QuotesProduct>();

            int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            int userRole = Int32.Parse(User.FindFirst("Role")?.Value);

            if (createQuote.AccessLevel == 0 || createQuote.AccessLevel < userRole)
            {
                createQuote.AccessLevel = userRole;
            }

            try
            {

                Quote createdQuote = await _quoteService.CreateQuote(QuoteDtoToEntity.CreateQuoteMapper(createQuote, userId));
                Console.WriteLine(createdQuote);
                if (createQuote.Products != null)
                {
                    foreach (AddProduct product in createQuote.Products)
                    {
                        try
                        {
                            Product productPattern = await _productService.GetById(product.ProductId);
                            Taxis tax;
                            if (product.TaxId != 0)
                            {
                                tax = await _taxService.GetById(Convert.ToInt32(product.TaxId));
                            }
                            else
                            {
                                tax = await _taxService.GetById(Convert.ToInt32(createdQuote.TaxesId));

                            }

                            QuotesProduct quoteProduct = new QuotesProduct
                            {
                                QuoteId = createdQuote.Id,
                                TaxesId = tax.Id,
                                Quantity = product.Quantity != 0 ? product.Quantity : 1,
                                TotalAmountWithoutTax = productPattern.Price * product.Quantity,
                                TotalAmountWithoutTaxWithDiscount = (productPattern.Price * (1 - product.Discount / 100)) * product.Quantity,
                                TotalAmountWithTaxWithDiscount = (productPattern.Price * (1 - product.Discount / 100)) * (1 + Convert.ToDecimal(tax.Percentage) / 100) * product.Quantity,
                                TotalTaxAmount = ((productPattern.Price * (1 - product.Discount / 100)) * (1 + Convert.ToDecimal(tax.Percentage) / 100) * product.Quantity) - ((productPattern.Price * (1 - product.Discount / 100)) * product.Quantity),
                                DiscountPercentage = product.Discount,
                                Description = product.Description,
                                CreatedBy = userId,
                                CreatedAt = DateTime.Now

                            };

                            quoteProduct.ProductId = productPattern != null ? productPattern.Id : null;
                            quoteProduct.OutOfCatalogProduct = productPattern == null ? product.Name : null;

                            await _quoteProductService.Create(quoteProduct);
                            quoteProductList.Add(quoteProduct);

                        } catch(Exception ex)
                        {
                            
                        }
                    }
                    createdQuote.TotalWithoutTaxWithDiscount = quoteProductList.Sum(qp => qp.TotalAmountWithoutTaxWithDiscount != null ? Convert.ToDecimal(qp.TotalAmountWithoutTaxWithDiscount) : 0);
                    createdQuote.TotalTaxAmount = quoteProductList.Sum(qp => qp.TotalTaxAmount != null ? Convert.ToDecimal(qp.TotalTaxAmount) : 0);
                    createdQuote.TotalWithTaxWithDiscount = quoteProductList.Sum(qp => qp.TotalAmountWithTaxWithDiscount != null ? Convert.ToDecimal(qp.TotalAmountWithTaxWithDiscount) : 0);
                    createdQuote.Total = quoteProductList.Sum(qp => qp.TotalAmountWithoutTax != null ? Convert.ToDecimal(qp.TotalAmountWithoutTax) : 0);

                    await _quoteService.Update(createdQuote);
                }
                Console.Write(createdQuote);
                return Ok(QuoteEntityToDto.ReadQuoteMapper(createdQuote));
            } catch(Exception ex)
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
