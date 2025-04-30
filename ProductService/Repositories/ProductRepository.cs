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



        public Task<Product> AddProduct(Product product)
        {
           _dbContext.Products.Add(product);
           _dbContext.SaveChangesAsync();

            return Task.FromResult(product);
        }

        public async Task<bool> DeleteProduct(Product productToDelete)
        {
            try
            {
                productToDelete.Deleted = true;
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> DesactivateProduct(Product productToDesactivate)
        {
            try
            {
                productToDesactivate.Deactivated = !productToDesactivate.Deactivated;
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
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
