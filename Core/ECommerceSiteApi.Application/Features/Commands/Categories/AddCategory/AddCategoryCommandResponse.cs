using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.CategoryDtos;

namespace ECommerceSiteApi.Application.Features.Commands.Categories.AddCategory;

public class AddCategoryCommandResponse
{
    public CustomResponseDto<CategoryDto> CustomResponseDto { get; set; }
}
