using ProductService.Models;

namespace ProductService.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetOneProduct(int productId);
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DesactivateProduct(int productId);
        Task DeleteProduct(int productId);
    }
}
