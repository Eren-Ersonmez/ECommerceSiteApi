

using ECommerceSiteApi.Application.Services.DataServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Products.GetProduct
{
    internal class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, GetProductQueryResponse>
    {
        public IProductDataService _productDataService;

        public GetProductQueryHandler(IProductDataService productDataService)
        => _productDataService = productDataService;
        

        public async Task<GetProductQueryResponse> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        => new() { CustomResponseDto = await _productDataService.GetProductWithImagesAsync(request.Id)};
            
        
    }
}
