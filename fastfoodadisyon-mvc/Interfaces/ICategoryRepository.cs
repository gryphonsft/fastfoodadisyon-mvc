using fastfoodadisyon_mvc.Models;

namespace fastfoodadisyon_mvc.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int Id);
        Task CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteByIdAsync(int Id);
        Task<IEnumerable<Category>> SearchAsync(string value);
    }
}
