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



        public async Task<Product> AddProduct(Product product)
        {
            try
            {
               _dbContext.Products.Add(product);
               await _dbContext.SaveChangesAsync();

               return product;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteProduct(Product productToDelete)
        {
                await _dbContext.SaveChangesAsync();
                return true;
        }

        public async Task<bool> DesactivateProduct(Product productToDesactivate)
        {
                await _dbContext.SaveChangesAsync();
                return true;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetOneProduct(int productId)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.IdProduct == productId);
        }
        public async Task<Product> GetProductByName(string productName)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Name == productName);

        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }
    }
}
