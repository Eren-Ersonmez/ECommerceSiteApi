using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.OrderDtos;

namespace ECommerceSiteApi.Application.Features.Queries.Orders.GetOrders;

public class GetOrdersQueryResponse
{
    public CustomResponseDto<IEnumerable<OrderDto>> CustomResponseDto { get; set; }
}
