
using ECommerceSiteApi.Application.Services.RoleServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Roles.GetRoles;

public class GetRolesQueryHandler : IRequestHandler<GetRolesQueryRequest, GetRolesQueryResponse>
{
    private readonly IRoleService _roleService;

    public GetRolesQueryHandler(IRoleService roleService)
    => _roleService = roleService;
    

    public async Task<GetRolesQueryResponse> Handle(GetRolesQueryRequest request, CancellationToken cancellationToken)
    => new() { CustomResponseDto = await _roleService.GetRolesAsync(new RequestParameters.Pagination(){Page=request.Page, PageSize=request.PageSize}) };
    
}
