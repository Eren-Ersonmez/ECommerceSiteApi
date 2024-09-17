using ECommerceSiteApi.Application.DTOs.BrandDtos;
using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSiteApi.Api.Controllers;

public class BrandsController : CustomBaseController
{
    private readonly IBrandDataService _brandService;

    public BrandsController(IBrandDataService brandService)
    => _brandService = brandService;

    [HttpGet]
    public async Task<IActionResult> GetBrands([FromQuery] Pagination pagination)
    => CreateActionResult(await _brandService.GetAllWithCategoryAsync(pagination)); 

    [HttpGet("[action]")]
    public async Task<IActionResult> GetCategoryBrands([FromQuery]string categoryId)
    => CreateActionResult(await _brandService.WhereAsync(x=>x.CategoryId==Guid.Parse(categoryId)));

    [HttpPost]
    public async Task<IActionResult> AddBrand([FromBody]BrandCreateDto dto)
    => CreateActionResult(await _brandService.AddAsync(dto));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBrand(string id)
    => CreateActionResult(await _brandService.DeleteAsync(id));
    
}
