

using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.Services;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationSevices.AssociateRoleAndEndpoint;

public class AssociateRoleAndEndpointCommandHandler : IRequestHandler<AssociateRoleAndEndpointCommandRequest, AssociateRoleAndEndpointCommandResponse>
{
    private readonly IAuthorizationEndpointService _authorizationEndpointService;

    public AssociateRoleAndEndpointCommandHandler(IAuthorizationEndpointService authorizationEndpointService)
    {
        _authorizationEndpointService = authorizationEndpointService;
    }

    public async Task<AssociateRoleAndEndpointCommandResponse> Handle(AssociateRoleAndEndpointCommandRequest request, CancellationToken cancellationToken)
    {
        CustomResponseDto<bool> result = null;
        if (request.Menu == null) 
        {
             result = await _authorizationEndpointService.AssignRoleEndpointAsync(request.Roles, request.EndpointCode);
        }
        else
        {
            result = await _authorizationEndpointService.AssignRoleEndpointAsync(request.Roles, request.EndpointCode, request.Type, request.Menu);
        }
       return new() { CustomResponseDto = result };
    }
}
