using Microsoft.AspNetCore.Mvc;
using BluePillCRM.Business.Services;
using BluePillCRM.Business.Dtos;
using BluePillCRM.Datas.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BluePillCRM.Application.WebApi.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [Authorize]
        [HttpGet("pagination")]
        public async Task<IActionResult> GetProducts([FromQuery] int page, [FromQuery] int amount)
        {
            int userRole = Int32.Parse(User.FindFirst("Role")?.Value);

            if(page == 0)
            {
                page = 1;
            }

            if(amount == 0)
            {
                amount = 25;
            }

            try
            {
                if (amount > 50)
                {
                    throw new Exception("La limite d'affichage est fixée à 50");
                }

                List<Product> products = await _productService.GetProductsByPage(page, amount).ConfigureAwait(false);
                return Ok(products.Select(product => ProductEntityToDto.ReadProductMapper(product)).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("getsingle/{id}")]
        public async Task<IActionResult> GetSingleProduct(int id)
        {
            
            try
            {
                if (id == 0)
                {
                    throw new Exception("Veuillez specifier un Id.");
                }
                Product product = await _productService.GetById(id).ConfigureAwait(false);
                return Ok(ProductEntityToDto.ReadProductMapper(product));
            } catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [Authorize]
        [HttpPost()]
        public async Task<IActionResult> Create(CreateProduct product)
        {
            int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if(userId == 0)
            {
                return BadRequest("Une erreur s'est produite. Veuillez vous reconnecter.");
            }
            try
            {
                Product createdProduct = await _productService.Create(ProductDtoToEntity.CreateProductMapper(product, userId));
                return Ok(createdProduct);
            }catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [Authorize]
        [HttpPatch()]
        public async Task<IActionResult> Update(UpdateProduct product)
        {
            int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            Product checkIfExists = await _productService.GetById(product.Id);
            if (checkIfExists == null)
            {
                return BadRequest("Une erreur s'est produite. Id incorrect.");
            }
            try
            {
                Product updatedProduct = await _productService.Update(ProductDtoToEntity.UpdateProductMapper(product, checkIfExists, userId));
                return Ok(updatedProduct);
            } catch (Exception ex)
            {
                return StatusCode(500, new {message = ex.Message});
            }
        }

        [Authorize]
        [HttpDelete()]
        public async Task<IActionResult> Delete(int id)
        {
            int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (id == 0)
            {
                return BadRequest("Une erreur s'est produite. Id incorrect.");
            }

            try
            {
                bool deleteProduct = await _productService.SoftDelete(id, userId).ConfigureAwait(false);
                return Ok("Produit supprimé avec succès");
            } catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message});
            }
        }

        [Authorize]
        [HttpPost("reactivate")]
        public async Task<IActionResult> ReActivateDeletedProduct(int id)
        {
            if (id == 0)
            {
                return BadRequest("Une erreur s'est produite. Veuillez vous reconnecter.");
            }

            try
            {
                Product recoveredProduct = await _productService.RecoverSoftDelete(id).ConfigureAwait(false);
                if(recoveredProduct != null)
                {
                    return Ok(recoveredProduct);
                } else
                {
                    return BadRequest("Une erreur s'est produite. Le produit n'a pas été trouvé.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }
}
