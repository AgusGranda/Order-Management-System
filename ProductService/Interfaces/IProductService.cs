using ProductService.Models;
using ProductService.Tools;

namespace ProductService.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetOneProduct(int productId);
        Task<OperationResult<Product>> AddProduct(Product product);
        Task<OperationResult<Product>> UpdateProduct(int idProduct,Product product);
        Task<OperationResult<Product>> DesactivateProduct(int productId);
        Task<OperationResult<Product>> DeleteProduct(int productId);
    }
}
