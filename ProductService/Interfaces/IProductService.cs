using ProductService.Models;
using ProductService.Tools;

namespace ProductService.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetOneProduct(int productId);
        Task<OperationResult> AddProduct(Product product);
        Task<OperationResult> UpdateProduct(int idProduct,Product product);
        Task<OperationResult> DesactivateProduct(int productId);
        Task<OperationResult> DeleteProduct(int productId);
    }
}
