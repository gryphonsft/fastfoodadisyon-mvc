using fastfoodadisyon_mvc.Context;
using fastfoodadisyon_mvc.Interfaces;
using fastfoodadisyon_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace fastfoodadisyon_mvc.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAllAsync() => await _context.Category.ToListAsync();
        public async Task<Category?> GetByIdAsync(int Id)
        {
            return await _context.Category.FirstOrDefaultAsync(p => p.Id == Id);
        }
        public async Task CreateAsync(Category category)
        {
            await _context.Category.AddAsync(category);
        }
        public async Task UpdateAsync(Category category)
        {
            _context.Category.Update(category);
        }
        public async Task DeleteByIdAsync(int Id)
        {
            var category = await GetByIdAsync(Id);

            if (category != null)
            {
                _context.Category.Remove(category);
            }
        }
        public async Task<IEnumerable<Category>> SearchAsync(string value)
        {
            return await _context.Category
                .Where(x => x.Name.Contains(value))
                .ToListAsync();
        }
    }
}
