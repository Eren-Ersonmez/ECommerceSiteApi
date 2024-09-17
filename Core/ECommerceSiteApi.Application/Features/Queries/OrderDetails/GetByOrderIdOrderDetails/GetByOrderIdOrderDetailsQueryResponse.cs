

using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.OrderDetailsDtos;

namespace ECommerceSiteApi.Application.Features.Queries.OrderDetails.GetByOrderIdOrderDetails;

public class GetByOrderIdOrderDetailsQueryResponse
{
    public CustomResponseDto<IEnumerable<OrderDetailsDto>> CustomResponseDto { get; set; }
}
