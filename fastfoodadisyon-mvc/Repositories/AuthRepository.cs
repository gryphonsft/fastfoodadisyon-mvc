using fastfoodadisyon_mvc.Context;
using fastfoodadisyon_mvc.Interfaces;
using fastfoodadisyon_mvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace fastfoodadisyon_mvc.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Users>> GetAllAsync() => await _context.Users.ToListAsync();
        public async Task<Users?> GetByIdAsync(int Id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);
        }
        public async Task CreateAsync(Users users)
        {
            await _context.AddAsync(users);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Users users)
        {
            _context.Update(users);
        }
        public async Task DeleteByIdAsync(int Id)
        {
            var users = await GetByIdAsync(Id);
            if(users != null)
            {
                _context.Users.Remove(users);
            }
        }
        public async Task<Users?> FindAsync(string searchkeyword)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.userName == searchkeyword || u.Email == searchkeyword);
        }
        
    }
}
