using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Application.Services.DataServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Products.GetProducts
{
    public class GetProductQueryHandlers : IRequestHandler<GetProductsQueryRequest, GetProductsQueryResponse>
    {
        private readonly IProductDataService _productDataService;
        public GetProductQueryHandlers(IProductDataService productDataService) 
        => _productDataService = productDataService;

        public async Task<GetProductsQueryResponse> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
        => new(){ CustomResponseDto = await _productDataService.GetAllAsync(new Pagination { Page = request.Page, PageSize = request.PageSize })};
        
    }
}
