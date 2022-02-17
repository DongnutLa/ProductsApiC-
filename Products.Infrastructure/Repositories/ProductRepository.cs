using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.Core.Entities;
using Products.Core.Interfaces;
using Products.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Products.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsAPIContext _context;
        public ProductRepository(ProductsAPIContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }
        public async Task<Product> GetProduct(int id)
        {
            var products = await _context.Products.FirstOrDefaultAsync(x=>x.Id == id);
            return products;
        }
        public async Task PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateProduct(Product product, Product currentProduct)
        {
            currentProduct.Name = product.Name;
            currentProduct.Description = product.Description;
            currentProduct.PurchaseDate = product.PurchaseDate;
            currentProduct.CategoryId = product.CategoryId;
            currentProduct.Price = product.Price;
            currentProduct.Active = product.Active;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> DeleteProduct(int id)
        {
            var currentProduct = await GetProduct(id);
            _context.Products.Remove(currentProduct);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
