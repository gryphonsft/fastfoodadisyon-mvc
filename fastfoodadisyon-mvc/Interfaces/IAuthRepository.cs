using fastfoodadisyon_mvc.Models;

namespace fastfoodadisyon_mvc.Interfaces
{
    public interface IAuthRepository
    {
        Task<IEnumerable<Users>> GetAllAsync();
        Task<Users?> GetByIdAsync(int Id);
        Task CreateAsync(Users users);
        Task UpdateAsync(Users users);
        Task DeleteByIdAsync(int Id);
        Task<Users?> FindAsync(string searchkeyword);
    }
}
