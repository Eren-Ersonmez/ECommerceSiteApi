

using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.CategoryDtos;

namespace ECommerceSiteApi.Application.Features.Queries.Categories.GetCategories;

public class GetCategoriesQueryResponse
{
    public CustomResponseDto<IEnumerable<CategoryDto>> CustomResponseDto { get; set; }
}
