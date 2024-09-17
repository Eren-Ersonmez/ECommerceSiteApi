

using ECommerceSiteApi.Application.Services.DataServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.Products.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
{
    private readonly IProductDataService _productDataService;

    public UpdateProductCommandHandler(IProductDataService productDataService)
    => _productDataService = productDataService;
    

    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    => new() {CustomResponseDto= await _productDataService.UpdateAsync(request.ProductUpdateDto)} ;
       
    
}
