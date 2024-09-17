

using ECommerceSiteApi.Application.Services.DataServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.Products.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductDataService _productDataService;

        public DeleteProductCommandHandler(IProductDataService productDataService)
        => _productDataService = productDataService;
        

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        => new() {CustomResponseDto= await _productDataService.DeleteAsync(request.Id) };
          
    }
}
