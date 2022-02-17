using Products.Core.Entities;

namespace Products.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task PostCategory(Category Category);
        Task<bool> UpdateCategory(Category Category);
        Task<bool> DeleteCategory(int id);
    }
}