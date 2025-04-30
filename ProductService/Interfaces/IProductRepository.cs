using ProductService.Models;

namespace ProductService.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetOneProduct(int productId);
        Task<Product> GetProductByName(string productName);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<bool> DesactivateProduct(Product productToDesactivate);
        Task<bool> DeleteProduct(Product productToDelete);
    }
}
