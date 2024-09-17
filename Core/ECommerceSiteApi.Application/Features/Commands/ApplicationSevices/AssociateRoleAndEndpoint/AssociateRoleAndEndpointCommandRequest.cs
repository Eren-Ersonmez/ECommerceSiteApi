using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationSevices.AssociateRoleAndEndpoint;

public class AssociateRoleAndEndpointCommandRequest:IRequest<AssociateRoleAndEndpointCommandResponse>
{
    public string[] Roles { get; set; }
    public string EndpointCode { get; set; }
    public string? Menu {  get; set; }
    public Type? Type { get; set; } = null; 
}