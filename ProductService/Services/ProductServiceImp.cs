﻿using ProductService.Interfaces;
using ProductService.Models;

namespace ProductService.Services
{
    public class ProductServiceImp : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductServiceImp(IProductRepository productRepository)
        {
            _productRepository = productRepository;
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
            throw new NotImplementedException();
        }

        public async Task<Product> GetOneProduct(int productId)
        {
            var product = _productRepository.GetOneProduct(productId);
            if(product != null)
                return product;

            return null;
        }

        public Task UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
