

using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.OrderDetails.GetOrderDetails;

public class GetOrderDetailsQueryRequest:IRequest<GetOrderDetailsQueryResponse>
{
    public string Id { get; set; }
}
