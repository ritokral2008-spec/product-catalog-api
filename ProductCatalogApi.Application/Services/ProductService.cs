using Microsoft.EntityFrameworkCore;
using ProductCatalogApi.Application.DTOs;
using ProductCatalogApi.Application.Interfaces;
using ProductCatalogApi.Domain.Entities;
using ProductCatalogApi.Infrastructure.Data;

namespace ProductCatalogApi.Application.Services;

public class ProductService: IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        return await _context.Products
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            })
            .ToListAsync();
    }

    public async Task<ProductDto?> UpdateAsync(int id, UpdateProductDto dto)
    {
        var product = await _context.Products.FindAsync(id);

        if(product == null)
            return null;

        product.Name = dto.Name;
        product.Price = dto.Price;
        product.CategoryId = dto.CategoryId;

        await _context.SaveChangesAsync();

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CategoryName = product.Category?.Name ?? ""
        };
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
     {
        var product = await _context.Products.FindAsync(id);

        if(product == null)
            return null;

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CategoryName = product.Category?.Name ?? ""
        };
     }

    public async Task<ProductDto> CreateAsync(CreateProductDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            CategoryId = dto.CategoryId
        };

        _context.Products.Add(product);

        await _context.SaveChangesAsync();

        await _context.Entry(product)
            .Reference(p => p.Category)
            .LoadAsync();

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CategoryName = product.Category?.Name ?? ""
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if(product == null)
            return false;

        _context.Products.Remove(product);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<ProductDto>> GetAllAsync(ProductQueryParameters parameters)
    {
        var query = _context.Products
            .Include(p => p.Category)
            .AsQueryable();

        // SEARCH
        if(!string.IsNullOrWhiteSpace(parameters.Search))
        {
            query = query.Where(p =>
                p.Name.ToLower().Contains(parameters.Search.ToLower()));
        }

        // MIN PRICE
        if(parameters.MinPrice.HasValue)
        {
            query = query.Where(p =>
                p.Price >= parameters.MinPrice.Value);
        }

        // MAX PRICE
        if(parameters.MaxPrice.HasValue)
        {
            query = query.Where(p =>
                p.Price <= parameters.MaxPrice.Value);
        }

        // PAGINATION
        query = query
            .Skip((parameters.Page - 1) * parameters.PageSize)
            .Take(parameters.PageSize);

        return await query
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryName = p.Category!.Name
            })
            .ToListAsync();
    }
}