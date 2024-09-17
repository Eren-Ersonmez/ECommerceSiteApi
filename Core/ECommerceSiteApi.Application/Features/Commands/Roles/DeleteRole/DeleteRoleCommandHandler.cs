

using ECommerceSiteApi.Application.Services.RoleServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.Roles.DeleteRole;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, DeleteRoleCommandResponse>
{
    private readonly IRoleService _roleService;

    public DeleteRoleCommandHandler(IRoleService roleService)
    => _roleService = roleService;
    

    public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
    => new() { CustomResponseDto = await _roleService.DeleteRoleAsync(request.Id) };
    
}
