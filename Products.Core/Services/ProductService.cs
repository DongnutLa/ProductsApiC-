using Products.Core.Entities;
using Products.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _productRepository.GetProduct(id);
            if (product == null)
            {
                throw new Exception("Product doesn't exist. Please check de product id");
            }
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productRepository.GetProducts();
        }

        public async Task PostProduct(Product product)
        {
            var category = await _categoryRepository.GetCategory(product.CategoryId);
            if (category == null)
            {
                throw new Exception("Category doesn't exist");
            }
            if (product.PurchaseDate > DateTime.Now)
            {
                throw new Exception("Purchase date must be earlier than the current date");
            }
            await _productRepository.PostProduct(product);
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var currentProduct = await GetProduct(product.Id);
            if (currentProduct == null)
            {
                throw new Exception("Product doesn't exist. Please check the product id");
            }
            if (product.PurchaseDate > DateTime.Now)
            {
                throw new Exception("Purchase date must be earlier than the current date");
            }
            return await _productRepository.UpdateProduct(product, currentProduct);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _productRepository.GetProduct(id);
            if (product == null)
            {
                throw new Exception("Product doesn't exist. Please check de product id");
            }
            return await _productRepository.DeleteProduct(id);
        }
    }
}
