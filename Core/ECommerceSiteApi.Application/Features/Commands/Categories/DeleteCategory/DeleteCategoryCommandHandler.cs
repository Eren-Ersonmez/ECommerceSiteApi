

using ECommerceSiteApi.Application.DTOs.CategoryDtos;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.Categories.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
{
    private readonly IDataService<Category,CategoryDto> _categoryService;

    public DeleteCategoryCommandHandler(IDataService<Category, CategoryDto> categoryService)
    => _categoryService = categoryService;
    

    public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
    => new() {CustomResponseDto = await _categoryService.DeleteAsync(request.Id) };
    
}
