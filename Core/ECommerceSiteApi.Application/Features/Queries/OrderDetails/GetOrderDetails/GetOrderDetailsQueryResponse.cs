

using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.OrderDetailsDtos;

namespace ECommerceSiteApi.Application.Features.Queries.OrderDetails.GetOrderDetails;

public class GetOrderDetailsQueryResponse
{
    public CustomResponseDto<OrderDetailsDto> CustomResponseDto { get; set; }
}
