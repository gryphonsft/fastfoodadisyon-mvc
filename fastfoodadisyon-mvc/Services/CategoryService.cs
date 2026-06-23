using fastfoodadisyon_mvc.DTOs;
using fastfoodadisyon_mvc.Interfaces;

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
    }
}
