

using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.OrderDetailsDtos;

namespace ECommerceSiteApi.Application.Features.Commands.OrderDetails.AddOrderDetails;

public class AddOrderDetailsCommandResponse
{
    public CustomResponseDto<OrderDetailsDto> CustomResponseDto { get; set; }
}
