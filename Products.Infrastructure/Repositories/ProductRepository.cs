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
    }
}
