using ProductService.Interfaces;
using ProductService.Models;

namespace ProductService.Services
{
    public class ProductServiceImp : IProductService
    {
        public ProductServiceImp()
        {
        }


        public Task<List<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetOneProduct()
        {
            var product = "Something async here!";
            return product;
        }
    }
}
