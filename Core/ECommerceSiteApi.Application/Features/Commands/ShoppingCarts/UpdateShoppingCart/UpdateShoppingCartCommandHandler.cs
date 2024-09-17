

using ECommerceSiteApi.Application.Services.DataServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ShoppingCarts.UpdateShoppingCart;

public class UpdateShoppingCartCommandHandler : IRequestHandler<UpdateShoppingCartCommandRequest, UpdateShoppingCartCommandResponse>
{
    private readonly IShoppingCartDataService _dataService;

    public UpdateShoppingCartCommandHandler(IShoppingCartDataService dataService)
    => _dataService = dataService;
    

    public async Task<UpdateShoppingCartCommandResponse> Handle(UpdateShoppingCartCommandRequest request, CancellationToken cancellationToken)
    => new() {CustomResponseDto= await _dataService.UpdateShoppingCartsAsync(request.UpdateShoppingCart)};
    
}
