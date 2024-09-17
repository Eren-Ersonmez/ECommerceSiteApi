
using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Application.DTOs.CategoryDtos;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Categories.GetCategories;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, GetCategoriesQueryResponse>
{
    private readonly IDataService<Category,CategoryDto> _categoryService;

    public GetCategoriesQueryHandler(IDataService<Category, CategoryDto> categoryService)
    => _categoryService = categoryService;
    

    async Task<GetCategoriesQueryResponse> IRequestHandler<GetCategoriesQueryRequest, GetCategoriesQueryResponse>.Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
    => new() {CustomResponseDto= await _categoryService.GetAllAsync(new Pagination() { Page = request.Page, PageSize = request.PageSize }) };
    
}
