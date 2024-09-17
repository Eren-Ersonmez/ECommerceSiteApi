

using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.OrderDtos;

namespace ECommerceSiteApi.Application.Features.Commands.Orders.AddOrder;

public class AddOrderCommandResponse
{
    public CustomResponseDto<OrderDto> CustomResponseDto { get; set; }
}
