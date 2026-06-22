using fastfoodadisyon_mvc.Models;

namespace fastfoodadisyon_mvc.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int Id);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteByIdAsync(int Id);
        Task<IEnumerable<Product>> SearchAsync(string value);
    }
}
