

using ECommerceSiteApi.Application.Services.DataServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.Orders.UpdateOrderStatus;

public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommandRequest, UpdateOrderStatusCommandResponse>
{
    private readonly IOrderDataService _orderDataService;

    public UpdateOrderStatusCommandHandler(IOrderDataService orderDataService)
    => _orderDataService = orderDataService;
    

    public async Task<UpdateOrderStatusCommandResponse> Handle(UpdateOrderStatusCommandRequest request, CancellationToken cancellationToken)
    => new() {CustomResponseDto= await _orderDataService.UpdateOrderStatusAsync(request.Id, request.OrderStatus) };
    
}
