using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Roles.GetRoles;

public class GetRolesQueryRequest:IRequest<GetRolesQueryResponse>
{
    public int Page { get; set; } = 0;
    public int PageSize { get; set; } = 5;
}