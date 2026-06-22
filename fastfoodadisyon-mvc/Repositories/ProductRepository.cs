using fastfoodadisyon_mvc.Context;
using fastfoodadisyon_mvc.Interfaces;
using fastfoodadisyon_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace fastfoodadisyon_mvc.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllAsync() => await _context.Product.ToListAsync();
        public async Task<Product?> GetByIdAsync(int Id)
        {
            return await _context.Product.FirstOrDefaultAsync(p => p.Id == Id);
        }
        public async Task CreateAsync(Product product)
        {
            await _context.Product.AddAsync(product);
        }
        public async Task UpdateAsync(Product product)
        {
            _context.Product.Update(product);
        }
        public async Task DeleteByIdAsync(int Id)
        {
            var product = await GetByIdAsync(Id);

            if(product != null)
            {
                _context.Product.Remove(product);
            }
        }
        public async Task<IEnumerable<Product>> SearchAsync(string value)
        {
            return await _context.Product
                .Where(x => x.Name.Contains(value))
                .ToListAsync();
        }
    }
}
