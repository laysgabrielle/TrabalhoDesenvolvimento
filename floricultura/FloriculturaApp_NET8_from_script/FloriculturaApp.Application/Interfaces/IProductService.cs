using FloriculturaApp.Application.DTOs;

namespace FloriculturaApp.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
        Task<ProductDto> AddAsync(ProductDto dto);
        Task<ProductDto> UpdateAsync(ProductDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ProductDto>> SearchAsync(string query);
    }
}
