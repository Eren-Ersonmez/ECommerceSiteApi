

using ECommerceSiteApi.Application.DTOs.CategoryDtos;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.Categories.UpdateCategory;

public class UpdateCategoryCommandRequest:IRequest<UpdateCategoryCommandResponse>
{
    public CategoryUpdateDto Category { get; set; }
}
