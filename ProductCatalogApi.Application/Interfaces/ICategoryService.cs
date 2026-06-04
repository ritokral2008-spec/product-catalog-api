    using ProductCatalogApi.Application.DTOs;

namespace ProductCatalogApi.Application.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllAsync();

    Task<CategoryDto?> GetByIdAsync(int id);

    Task<CategoryDto> CreateAsync(CreateCategoryDto dto);

    Task<bool> DeleteAsync(int id);
}