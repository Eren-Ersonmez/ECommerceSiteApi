using ECommerceSiteApi.Application.DTOs.CategoryDtos;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.Categories.AddCategory;

public class AddCategoryCommandRequest : IRequest<AddCategoryCommandResponse>
{
    public CategoryCreateDto CreateDto { get; set; }
}
