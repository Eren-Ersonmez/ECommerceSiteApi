using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationSevices.GetSelectedRolesOfEndpoint;

public class GetSelectedRolesOfEndpointCommandRequest:IRequest<GetSelectedRolesOfEndpointCommandResponse>
{
    public string EndpointCode { get; set; }
}