using ECommerceSiteApi.Application.DTOs.ProductAttributeDtos;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSiteApi.Api.Controllers;

public class ProductAttributesController : CustomBaseController
{
    private readonly IDataService<ProductAttribute,ProductAttributeDto> _productAttributeService;

    public ProductAttributesController(IDataService<ProductAttribute, ProductAttributeDto> productAttributeService)
    {
        _productAttributeService = productAttributeService;
    }

    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProductAttributes(string productId)
    => CreateActionResult(await _productAttributeService.WhereAsync(x=>x.ProductId==Guid.Parse(productId)));

    [HttpPost]
    public async Task<IActionResult> AddProductAttribute(ProductAttributeCreateDto dto)
    => CreateActionResult(await _productAttributeService.AddAsync(dto));

}
