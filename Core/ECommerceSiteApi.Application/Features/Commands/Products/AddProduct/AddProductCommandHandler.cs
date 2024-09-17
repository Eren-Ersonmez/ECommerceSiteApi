
using ECommerceSiteApi.Application.Services.DataServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.Products.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
    {
        private readonly IProductDataService _productDataService;

        public AddProductCommandHandler(IProductDataService productDataService)
        => _productDataService = productDataService;
   

        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        => new() {CustomResponseDto= await _productDataService.AddAsync(request.Dto)};
            
        
    }
}
