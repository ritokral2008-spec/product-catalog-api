using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalogApi.Application.DTOs;
using ProductCatalogApi.Application.Interfaces;
using ProductCatalogApi.Domain.Entities;
using ProductCatalogApi.Infrastructure.Data;
using System.Runtime.InteropServices;

namespace ProductCatalogApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController: ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }



    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetProducts(
    [FromQuery] ProductQueryParameters parameters)
    {
        var products = await _productService.GetAllAsync(parameters);

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var product = await _productService.GetByIdAsync(id);

        if(product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto dto)
    {
        var createdProduct = await _productService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetProduct),
            new { id = createdProduct.Id },
            createdProduct);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto dto)
    {
        var updated = await _productService.UpdateAsync(id, dto);

        if(updated == null)
            return NotFound();

        return NoContent();
    }
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")] // только админ
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var deleted = await _productService.DeleteAsync(id);

        if(!deleted)
            return NotFound();

        return NoContent();
    }
}