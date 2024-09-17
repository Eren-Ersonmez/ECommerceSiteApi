

using ECommerceSiteApi.Application.Services.DataServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.ApplicationUsers.GetUsersRoles;

public class GetUsersRolesQueryHandler : IRequestHandler<GetUsersRolesQueryRequest, GetUsersRolesResponse>
{
    private readonly IUserService _userService;

    public GetUsersRolesQueryHandler(IUserService userService)
    => _userService = userService;
    

    public async Task<GetUsersRolesResponse> Handle(GetUsersRolesQueryRequest request, CancellationToken cancellationToken)
    => new() { CustomResponseDto=await _userService.GetUsersRolesAsync(request.UserId)};
    
}
