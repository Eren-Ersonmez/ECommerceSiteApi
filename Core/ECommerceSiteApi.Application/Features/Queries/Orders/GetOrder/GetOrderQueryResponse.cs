
using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.OrderDtos;

namespace ECommerceSiteApi.Application.Features.Queries.Orders.GetOrder;

public class GetOrderQueryResponse
{
    public CustomResponseDto<OrderDto> CustomResponseDto { get; set; }
}
