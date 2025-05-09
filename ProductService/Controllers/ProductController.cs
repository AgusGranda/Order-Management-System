using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductService.Interfaces;
using ProductService.Models;
using ProductService.Tools;
using SendGrid.Helpers.Errors.Model;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _IProductService;

        public ProductController(IProductService IproductService)
        {
            _IProductService = IproductService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                var result = await _IProductService.GetAllProducts();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("{idProduct}")]
        public async Task<ActionResult<Product>> Get(int idProduct)
        {
            try
            {

                var response = await _IProductService.GetOneProduct(idProduct);
                return Ok(response);

            }
            catch (NotFoundException ex)
            {
                return NotFound(new {message = ex.Message});
            }
        }


        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                    return UnprocessableEntity(ModelState);

                var result = await _IProductService.AddProduct(product);
                if(!result.Success)
                    return BadRequest(result.Message);

                return CreatedAtAction("GetOneProduct", new { id = result.Data.IdProduct } , result.Data);
            }
            catch(DbUpdateException ex)
            {
                return StatusCode(500, "Database error");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Unexpected error");
            }
        }

        // Activa o desactiva un producto
        [HttpPatch("{idProduct}")]
        public async Task<ActionResult<OperationResult<Product>>> UpdateActiveProduct(int idProduct)
        {
            try
            {
                
                var result =  await _IProductService.DesactivateProduct(idProduct);
                if (!result.Success)
                    return BadRequest(result.Message);

                return Ok(result.Message);
            }
            catch (NotFoundException)
            {
                return NotFound(new { message = "Product not found" });
            }
            catch(Exception)
            {
                return StatusCode(500, "Unexpected error");
            }
        }

        [HttpPut("{idProduct}")]
        public async Task<ActionResult> UpdateProduct(int idProduct , Product productEdited)
        {
            try
            {
                if(!ModelState.IsValid)
                    return UnprocessableEntity(ModelState);

                var result = await _IProductService.UpdateProduct(idProduct, productEdited);
                if(!result.Success)
                    return BadRequest(result.Message);

                return Ok(result.Message);
            }
            catch (NotFoundException)
            {
                return NotFound(new { message = "Product not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Unexpected error");
            }
        }

        // Soft delete de producto
        [HttpDelete("{idProduct}")]
        public async Task<ActionResult> DesactivateProduct(int idProduct)
        {
            try
            {
                var result = await _IProductService.DeleteProduct(idProduct);
                if(!result.Success)
                    return BadRequest(result.Message);

                return Ok(result.Message);

            }
            catch (NotFoundException)
            {
                return NotFound(new { message = "Product not found" });
            }
            catch (Exception)
            {
                return StatusCode(500, "Unexpected error");
            }
        }

    }
}
