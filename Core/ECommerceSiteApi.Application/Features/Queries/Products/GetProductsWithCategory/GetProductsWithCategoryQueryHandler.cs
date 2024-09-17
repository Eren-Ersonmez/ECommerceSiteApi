

using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Application.Services.DataServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Products.GetProductsWithCategory
{
    public class GetProductsWithCategoryQueryHandler : IRequestHandler<GetProductsWithCategoryQueryRequest, GetProductsWithCategoryQueryResponse>
    {
        private readonly IProductDataService _productDataService;

        public GetProductsWithCategoryQueryHandler(IProductDataService productDataService)
        => _productDataService = productDataService;
        

        public async Task<GetProductsWithCategoryQueryResponse> Handle(GetProductsWithCategoryQueryRequest request, CancellationToken cancellationToken)
        => new() { CustomResponseDto = await _productDataService.GetAllWithCategoryAsync(new Pagination { Page = request.Page, PageSize = request.PageSize })};
        
    }
}
