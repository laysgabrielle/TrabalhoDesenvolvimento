using FloriculturaApp.Application.DTOs;
using FloriculturaApp.Application.Interfaces;
using FloriculturaApp.Domain.Entities;
using FloriculturaApp.Domain.Interfaces;
using Mapster;

namespace FloriculturaApp.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _repository;

        public ProductService(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Adapt<IEnumerable<ProductDto>>();
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity?.Adapt<ProductDto>();
        }

        public async Task<ProductDto> AddAsync(ProductDto dto)
        {
            var entity = dto.Adapt<Product>();
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return entity.Adapt<ProductDto>();
        }

        public async Task<ProductDto> UpdateAsync(ProductDto dto)
        {
            var entity = dto.Adapt<Product>();
            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
            return entity.Adapt<ProductDto>();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                await _repository.DeleteAsync(entity);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductDto>> SearchAsync(string query)
        {
            var entities = await _repository.GetAllAsync();
            var results = entities.Where(p => p.Name.Contains(query, StringComparison.OrdinalIgnoreCase));
            return results.Adapt<IEnumerable<ProductDto>>();
        }
    }
}
