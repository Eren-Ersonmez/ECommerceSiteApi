

using ECommerceSiteApi.Application.Services.DataServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.AssignRoles;

public class AssignRolesCommandHandler : IRequestHandler<AssignRolesCommandRequest, AssignRolesCommandResponse>
{
    private readonly IUserService _userService;

    public AssignRolesCommandHandler(IUserService userService)
    => _userService = userService;
    

    public async Task<AssignRolesCommandResponse> Handle(AssignRolesCommandRequest request, CancellationToken cancellationToken)
    {
        return new() {CustomResponseDto=await _userService.AssignRoles(request.UserId,request.Roles) };
    }
}
