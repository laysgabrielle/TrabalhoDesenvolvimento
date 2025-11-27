using FloriculturaApp.Application.DTOs;
using FloriculturaApp.Application.Interfaces;
using FloriculturaApp.Domain.Entities;
using FloriculturaApp.Domain.Interfaces;
using Mapster;

namespace FloriculturaApp.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _repository;

        public CategoryService(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Adapt<IEnumerable<CategoryDto>>();
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity?.Adapt<CategoryDto>();
        }

        public async Task<CategoryDto> AddAsync(CategoryDto dto)
        {
            var entity = dto.Adapt<Category>();
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return entity.Adapt<CategoryDto>();
        }

        public async Task<CategoryDto> UpdateAsync(CategoryDto dto)
        {
            var entity = dto.Adapt<Category>();
            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
            return entity.Adapt<CategoryDto>();
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
    }
}
