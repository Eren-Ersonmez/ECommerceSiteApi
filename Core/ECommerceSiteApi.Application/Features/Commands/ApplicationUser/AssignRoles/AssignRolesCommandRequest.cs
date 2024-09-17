using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.AssignRoles;

public class AssignRolesCommandRequest:IRequest<AssignRolesCommandResponse>
{
    public string? UserId { get; set; }
    public string[]? Roles { get; set; }
}