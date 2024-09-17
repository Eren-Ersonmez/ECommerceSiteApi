

using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.CategoryDtos;

namespace ECommerceSiteApi.Application.Features.Queries.Categories.GetCategory;

public class GetCategoryQueryResponse
{
   public CustomResponseDto<CategoryDto> CustomResponseDto { get; set; }
}
