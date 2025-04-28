using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Interfaces;
using ProductService.Models;

namespace ProductService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext) 
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

        public async Task<List<Product>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
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
