

using ECommerceSiteApi.Application.DTOs.ProductDtos;
using ECommerceSiteApi.Application.Services.DataServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.Products.UpdateStockQrCodeToProduct;

public class UpdateStockQrCodeToProductCommandHandler : IRequestHandler<UpdateStockQrCodeToProductCommandRequest, UpdateStockQrCodeToProductCommandResponse>
{
    private readonly IProductDataService _productDataService;

    public UpdateStockQrCodeToProductCommandHandler(IProductDataService productDataService)
    => _productDataService = productDataService;
    

    public async Task<UpdateStockQrCodeToProductCommandResponse> Handle(UpdateStockQrCodeToProductCommandRequest request, CancellationToken cancellationToken)
    => new() { CustomResponseDto = await _productDataService.UpdateStockQrCodeToProduct(request.ProductId, request.Stock) };
    
}
