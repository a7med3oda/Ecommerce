using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly EcommerceDbContext _context;           // for database
        public CategoryServices(EcommerceDbContext context)     // ctor for Dependency injection
        {
            _context = context;
        }
        public async Task CreateAsync(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var categoryId = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (categoryId != null)
            {
                _context.Categories.Remove(categoryId);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Category entity)
        {
            var categoryId = await _context.Categories.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (categoryId != null)
            {
                categoryId.Id = entity.Id;
                categoryId.Name = entity.Name;
                categoryId.Description = entity.Description;
                await _context.SaveChangesAsync();
            }
        }
    }
}
