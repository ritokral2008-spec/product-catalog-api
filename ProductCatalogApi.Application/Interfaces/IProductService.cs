using ProductCatalogApi.Application.DTOs;
using ProductCatalogApi.Domain.Entities;
namespace ProductCatalogApi.Application.Interfaces;

public interface IProductService
{
   
    Task<IEnumerable<ProductDto>> GetAllAsync();

    Task<ProductDto?> GetByIdAsync(int id);

    Task<ProductDto> CreateAsync(CreateProductDto dto);

    Task<ProductDto?> UpdateAsync(int id, UpdateProductDto dto);

    Task<bool> DeleteAsync(int id);

    Task<List<ProductDto>> GetAllAsync(ProductQueryParameters parameters);
}