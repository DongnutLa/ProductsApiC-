using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.Core.Entities;

namespace Products.Infrastructure.Repositories
{
    public class ProductRepository
    {
        public IEnumerable<Product> GetProducts()
        {
            var products = Enumerable.Range(1, 10).Select(i => new Product
            {
                ProductId = i,
                Name = $"Name {i}",
                Description = $"Description {i}",
                TypeId = i,
                Price = i*10,
                PurchaseDate = DateTime.Now,
                Active = true,
            });

            return products;
        }
    }
}
