using ProductService.Models;

namespace ProductService.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetOneProduct();
    }
}
