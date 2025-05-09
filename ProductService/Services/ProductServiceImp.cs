using ProductService.Interfaces;
using ProductService.Models;
using ProductService.Tools;
using SendGrid.Helpers.Errors.Model;

namespace ProductService.Services
{
    public class ProductServiceImp : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductServiceImp(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return products;
        }

        public async Task<Product> GetOneProduct(int productId)
        {
            var product = await _productRepository.GetOneProduct(productId);
            if (product == null)
            {
                throw new NotFoundException($"Product with id {productId} not found");
            }
            return product;
        }

        public async Task<OperationResult<Product>> AddProduct(Product product)
        {
            
            var productExist = await _productRepository.GetProductByName(product.Name);

            if (productExist != null)
            {
                return new OperationResult<Product>
                {
                    Success = false,
                    Message = "Product already exists",
                    Data = null
                };
            }
            var createdProduct =  await _productRepository.AddProduct(product);

            return new OperationResult<Product>
            {
                Success = true,
                Message = "Product created successfully",
                Data = createdProduct
            }; 
        }

        public async Task<OperationResult<Product>> UpdateProduct(int idProduct, Product product)
        {
            var productExist = await _productRepository.GetOneProduct(idProduct);

            if (productExist == null)
                throw  new NotFoundException($"Product with id {idProduct} not found");

            var productUpdated = await _productRepository.UpdateProduct(product);
            if (productUpdated == null)
            {
                return new OperationResult<Product>
                {
                    Success = false,
                    Message = "Product not updated",
                    Data = null
                };
            }
            return new OperationResult<Product>
            {
                Success = true,
                Message = "Product updated successfully",
                Data = productUpdated
            };
        }

        public async Task<OperationResult<Product>> DesactivateProduct(int productId)
        {
            var productToDesactivate = await _productRepository.GetOneProduct(productId);
            if(productToDesactivate == null)
                throw new NotFoundException();
            bool productDesactivated = await _productRepository.DesactivateProduct(productToDesactivate);
            return new OperationResult<Product>
            {
                Success = true,
                Message = "Product desactivated successfully",
                Data = null
            };
        }
        public async Task<OperationResult<Product>> DeleteProduct(int productId)
        {

            try
            {
                var productToDelete = await _productRepository.GetOneProduct(productId);
                if (productToDelete == null)
                    throw new NotFoundException();

                bool productDeleted = await _productRepository.DesactivateProduct(productToDelete);
                if (!productDeleted)
                    throw new Exception();

                return new OperationResult<Product>
                {
                    Success = true,
                    Message = "Product deleted successfully",
                    Data = null
                };

                
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
