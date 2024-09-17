using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.Orders.UpdateOrderStatus;

public class UpdateOrderStatusCommandRequest:IRequest<UpdateOrderStatusCommandResponse> 
{
    public string Id { get; set; }
    public string OrderStatus {  get; set; }    
}