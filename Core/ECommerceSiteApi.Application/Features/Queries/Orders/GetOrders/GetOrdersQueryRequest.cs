

using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Orders.GetOrders;

public class GetOrdersQueryRequest:IRequest<GetOrdersQueryResponse>
{
    public int Page { get; set; } = 0;
    public int PageSize { get; set; } = 5;
}
