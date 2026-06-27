using fastfoodadisyon_mvc.DTOs;
using fastfoodadisyon_mvc.Interfaces;
using fastfoodadisyon_mvc.Models;

namespace fastfoodadisyon_mvc.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository,IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var category = await _categoryRepository.GetAllAsync();

            return category.Select(x => new CategoryDto
            {
                Name = x.Name
            }).ToList();
        }
        public async Task<CategoryDto?> GetByIdAsync(int Id)
        {
            var category = await _categoryRepository.GetByIdAsync(Id);

            if (category == null)
                return null;

            return new CategoryDto
            {
                Name = category.Name
            };
        }

        public async Task CreateAsync(CategoryCreate dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                CreatedAt = DateTime.UtcNow
            };
            await _categoryRepository.CreateAsync(category);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
