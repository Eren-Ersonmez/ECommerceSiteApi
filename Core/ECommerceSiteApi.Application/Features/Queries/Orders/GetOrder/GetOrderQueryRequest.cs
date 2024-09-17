

using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Orders.GetOrder;

public class GetOrderQueryRequest:IRequest<GetOrderQueryResponse>
{
    public string Id { get; set; }
}
