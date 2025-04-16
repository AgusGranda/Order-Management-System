using ProductService.Data;
using ProductService.Interfaces;
using ProductService.Models;

namespace ProductService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _dbContext;
        public ProductRepository(DbContext dbContext) 
        {
            _dbContext = dbContext;
        }



        public Task AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task DesactivateProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Task<Product> GetOneProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
