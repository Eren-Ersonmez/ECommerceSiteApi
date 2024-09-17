

using ECommerceSiteApi.Application.DTOs.CategoryDtos;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.Categories.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
{
    private readonly IDataService<Category,CategoryDto> _categoryService;

    public UpdateCategoryCommandHandler(IDataService<Category, CategoryDto> categoryService)
    => _categoryService = categoryService;


    public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
    =>new() { CustomResponseDto= await _categoryService.UpdateAsync(request.Category) };
    
}
