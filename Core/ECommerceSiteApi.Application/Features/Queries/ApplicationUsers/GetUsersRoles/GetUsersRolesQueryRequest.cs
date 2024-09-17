using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.ApplicationUsers.GetUsersRoles;

public class GetUsersRolesQueryRequest:IRequest<GetUsersRolesResponse>
{
    public string UserId { get; set; }
}
