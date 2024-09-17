using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.ApplicationUsers.GetUsers;

public class GetUsersQueryRequest:IRequest<GetUsersQueryResponse>
{
    public int Page { get; set; } = 0;
    public int PageSize { get; set; } = 5;
}