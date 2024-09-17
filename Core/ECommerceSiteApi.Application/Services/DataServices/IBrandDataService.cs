

using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.BrandDtos;
using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Services.DataServices;

public interface IBrandDataService:IDataService<Brand,BrandDto> 
{
    Task<CustomResponseDto<List<BrandDto>>> GetAllWithCategoryAsync(Pagination pagination);
}
