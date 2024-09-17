
using ECommerceSiteApi.Application.Services.DataServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Products.GetProductQrCode;

public class GetProductQrCodeQueryHandler : IRequestHandler<GetProductQrCodeQueryRequest, GetProductQrCodeQueryResponse>
{
    private readonly IProductDataService _productDataService;

    public GetProductQrCodeQueryHandler(IProductDataService productDataService)
    => _productDataService = productDataService;
    

    public async Task<GetProductQrCodeQueryResponse> Handle(GetProductQrCodeQueryRequest request, CancellationToken cancellationToken)
    => new() {CustomResponseDto= await _productDataService.QRCodeToProductAsync(request.ProductId) };
    
}
