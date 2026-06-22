using fastfoodadisyon_mvc.DTOs;
using fastfoodadisyon_mvc.Interfaces;
using fastfoodadisyon_mvc.Models;
using fastfoodadisyon_mvc.Repositories;

namespace fastfoodadisyon_mvc.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(ProductRepository productRepository,IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var product = await _productRepository.GetAllAsync();

            return product.Select(x => new ProductDto
            {
                Name = x.Name,
                CreatedAt = x.CreatedAt
            }).ToList();
        }
        public async Task<ProductDto?> GetByIdAsync(int Id)
        {
            var product = await _productRepository.GetByIdAsync(Id);

            if (product == null)
                return null;

            return new ProductDto
            {
                Name = product.Name,
                CreatedAt = product.CreatedAt
            };
        }
        public async Task CreateAsync(ProductCreate request)
        {
            var product = new Product
            {
                Name = request.Name,
                CategoryID = request.CategoryID,
                CreatedAt = request.CreatedAt
            };

            await _productRepository.CreateAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
