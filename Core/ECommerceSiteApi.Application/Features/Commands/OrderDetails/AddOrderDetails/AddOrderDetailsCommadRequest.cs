using ECommerceSiteApi.Application.DTOs.OrderDetailsDtos;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.OrderDetails.AddOrderDetails;

public class AddOrderDetailsCommadRequest:IRequest<AddOrderDetailsCommandResponse>
{
    public OrderDetailsCreateDto CreateDto { get; set; }
}
