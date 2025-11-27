using FloriculturaApp.Application.DTOs;
using FloriculturaApp.Domain.Entities;
using Mapster;

namespace FloriculturaApp.Application.Mapping
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Category, CategoryDto>.NewConfig();
            TypeAdapterConfig<CategoryDto, Category>.NewConfig();

            TypeAdapterConfig<Product, ProductDto>.NewConfig();
            TypeAdapterConfig<ProductDto, Product>.NewConfig();
        }
    }
}
