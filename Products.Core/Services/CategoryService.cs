using Products.Core.Entities;
using Products.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.Core.Exceptions;

namespace Products.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> GetCategory(int id)
        {
            var Category = await _categoryRepository.GetCategory(id);
            if (Category == null)
            {
                throw new ProductsExceptions("Category doesn't exist. Please check de Category id");
            }
            return Category;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryRepository.GetCategories();
        }

        public async Task PostCategory(Category Category)
        {
            await _categoryRepository.PostCategory(Category);
        }

        public async Task<bool> UpdateCategory(Category Category)
        {
            var currentCategory = await GetCategory(Category.Id);
            if (currentCategory == null)
            {
                throw new ProductsExceptions("Category doesn't exist. Please check the Category id");
            }
            return await _categoryRepository.UpdateCategory(Category, currentCategory);
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var Category = await _categoryRepository.GetCategory(id);
            if (Category == null)
            {
                throw new ProductsExceptions("Category doesn't exist. Please check de Category id");
            }
            return await _categoryRepository.DeleteCategory(id);
        }
    }
}
