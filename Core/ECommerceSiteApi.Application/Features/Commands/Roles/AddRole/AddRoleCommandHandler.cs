

using ECommerceSiteApi.Application.Services.RoleServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.Roles.AddRole;

public class AddRoleCommandHandler : IRequestHandler<AddRoleCommandRequest, AddRoleCommandResponse>
{
    private readonly IRoleService _roleService;

    public AddRoleCommandHandler(IRoleService roleService)
    => _roleService = roleService;
    

    public async Task<AddRoleCommandResponse> Handle(AddRoleCommandRequest request, CancellationToken cancellationToken)
    => new() {CustomResponseDto= await _roleService.CreateRoleAsync(request.RoleName) };

}
