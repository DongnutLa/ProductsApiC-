using Products.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Core.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Task<Product> GetProduct(int id);
        Task PostProduct(Product product);
        Task<bool> UpdateProduct(Product product, Product currentProduct);
        Task<bool> DeleteProduct(int id);
    }
}
