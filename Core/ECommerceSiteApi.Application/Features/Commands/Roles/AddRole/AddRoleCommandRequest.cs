using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.Roles.AddRole;

public class AddRoleCommandRequest:IRequest<AddRoleCommandResponse>
{
    public string RoleName { get; set; }
}