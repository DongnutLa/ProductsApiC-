using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Products.Core.Entities;
using Products.Core.Interfaces;
using Products.Infrastructure.Data;

namespace Products.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductsAPIContext _context;
        public CategoryRepository(ProductsAPIContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category> GetCategory(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            return category;
        }

        public async Task PostCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateCategory(Category category, Category currentCategory)
        {
            currentCategory.Name = category.Name;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> DeleteCategory(int id)
        {
            var currentCategory = await GetCategory(id);
            _context.Categories.Remove(currentCategory);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
