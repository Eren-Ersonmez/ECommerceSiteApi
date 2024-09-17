using ECommerceSiteApi.Application.DTOs;

namespace ECommerceSiteApi.Application.Features.Commands.Orders.UpdateOrderStatus;

public class UpdateOrderStatusCommandResponse
{
    public CustomResponseDto<bool> CustomResponseDto { get; set; }
}