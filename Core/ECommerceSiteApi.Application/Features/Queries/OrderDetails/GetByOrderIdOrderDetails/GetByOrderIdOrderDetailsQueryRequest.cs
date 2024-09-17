

using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.OrderDetails.GetByOrderIdOrderDetails;
public class GetByOrderIdOrderDetailsQueryRequest:IRequest<GetByOrderIdOrderDetailsQueryResponse>
{
    public string OrderId { get; set; }
}
