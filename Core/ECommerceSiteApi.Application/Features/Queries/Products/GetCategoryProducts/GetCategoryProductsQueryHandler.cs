

using ECommerceSiteApi.Application.Services.DataServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Products.GetCategoryProducts;

public class GetCategoryProductsQueryHandler : IRequestHandler<GetCategoryProductsQueryRequest, GetCategoryProductsQueryResponse>
{
    private readonly IProductDataService _productDataService;

    public GetCategoryProductsQueryHandler(IProductDataService productDataService)
    => _productDataService = productDataService;
    

    public async Task<GetCategoryProductsQueryResponse> Handle(GetCategoryProductsQueryRequest request, CancellationToken cancellationToken)
    {
      var datas= await _productDataService.WhereAsync(x=>x.CategoryId==Guid.Parse(request.CategoryId));
      return new() { CustomResponseDto = datas };
    }
}
