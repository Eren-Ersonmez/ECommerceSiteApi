

using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Addresses.GetAddress;

public class GetAddressQueryRequest:IRequest<GetAddressQueryResponse>
{
    public string Id { get; set; }
}
