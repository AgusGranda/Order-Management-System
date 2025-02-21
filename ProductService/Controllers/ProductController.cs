using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Interfaces;
using ProductService.Models;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly  IProductService _IProductService;

        public ProductController(IProductService IproductService)
        {
            _IProductService = IproductService;
        }

        [HttpGet]
        public async Task<ActionResult<Product>> Get()
        {
            var response = await _IProductService.GetAllProducts();
            return Ok(response);
        }
    }
}
