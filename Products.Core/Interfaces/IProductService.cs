using Products.Core.Entities;
using Products.Core.QueryFilters;

namespace Products.Core.Interfaces
{
    public interface IProductService
    {
        PagedList<Product> GetProducts(ProductQueryFilter filters);
        Task<Product> GetProduct(int id);
        Task PostProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
    }
}