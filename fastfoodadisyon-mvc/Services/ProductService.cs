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

        public ProductService(ProductRepository productRepository, IUnitOfWork unitOfWork)
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
        public async Task UpdateAsync(int Id, ProductUpdate dto)
        {
            var request = await _productRepository.GetByIdAsync(Id);

            if (request == null)
                throw new Exception("Ürün bulunamadı");

            request.Name = request.Name;
            request.CategoryID = request.CategoryID;

            await _productRepository.UpdateAsync(request);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteByIdAsync(int Id)
        {
            var product = await _productRepository.GetByIdAsync(Id);

            if (product == null)
                throw new Exception("Ürün bulunamadı");

            await _productRepository.DeleteByIdAsync(Id);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<IEnumerable<ProductDto>> SearchAsync(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Enumerable.Empty<ProductDto>();

            var products = await _productRepository.SearchAsync(value);

            return products.Select(x => new ProductDto
            {
                Name = x.Name,
                CreatedAt = x.CreatedAt
            });
        }
    }
}
