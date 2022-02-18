using Products.Core.Entities;
using Products.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.Core.Exceptions;
using Products.Core.QueryFilters;

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
                throw new ProductsExceptions("Product doesn't exist. Please check de product id");
            }
            return product;
        }

        public PagedList<Product> GetProducts(ProductQueryFilter filters)
        {
            var products = _productRepository.GetProducts();
            if (filters.description != null)
            {
                products = products.Where(p => p.Description.ToLower().Contains(filters.description.ToLower()));
            }
            if (filters.PageNumber == null || filters.PageNumber == 0) filters.PageNumber = 1;
            if (filters.PageSize == null || filters.PageSize == 0) filters.PageSize = (int)Math.Ceiling(products.Count() / (double)filters.PageNumber);

            var pagedProducts = PagedList<Product>.Create(products, (int)filters.PageNumber, (int)filters.PageSize);
            return pagedProducts;
        }

        public async Task PostProduct(Product product)
        {
            var category = await _categoryRepository.GetCategory(product.CategoryId);
            if (category == null)
            {
                throw new ProductsExceptions("Category doesn't exist please check the categories that are available");
            }
            if (product.PurchaseDate > DateTime.Now)
            {
                throw new ProductsExceptions("Purchase date must be earlier than the current date");
            }
            await _productRepository.PostProduct(product);
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var currentProduct = await GetProduct(product.Id);
            if (currentProduct == null)
            {
                throw new ProductsExceptions("Product doesn't exist. Please check the product id");
            }
            if (product.PurchaseDate > DateTime.Now)
            {
                throw new ProductsExceptions("Purchase date must be earlier than the current date");
            }
            return await _productRepository.UpdateProduct(product, currentProduct);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _productRepository.GetProduct(id);
            if (product == null)
            {
                throw new ProductsExceptions("Product doesn't exist. Please check de product id");
            }
            return await _productRepository.DeleteProduct(id);
        }
    }
}
