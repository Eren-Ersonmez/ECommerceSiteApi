using ECommerceSiteApi.Application.DTOs;

namespace ECommerceSiteApi.Application.Features.Commands.Categories.DeleteCategory;

public class DeleteCategoryCommandResponse
{
    public CustomResponseDto<bool> CustomResponseDto { get; set; }
}
