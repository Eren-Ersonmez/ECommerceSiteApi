
using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Addresses.GetAddresses;

public class GetAddressesQueryRequest:IRequest<GetAddressesQueryResponse>
{
    public int Page { get; set; } = 0;
    public int PageSize { get; set; } = 5;
}
