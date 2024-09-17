

using ECommerceSiteApi.Application.DTOs.CategoryDtos;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Categories.GetCategory;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, GetCategoryQueryResponse>
{
    private IDataService<Category,CategoryDto> _categoryService;

    public GetCategoryQueryHandler(IDataService<Category, CategoryDto> categoryService)
    =>  _categoryService = categoryService;
    

    public async Task<GetCategoryQueryResponse> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
    => new() {CustomResponseDto=await _categoryService.GetByIdAsync(request.Id) };
    
}
