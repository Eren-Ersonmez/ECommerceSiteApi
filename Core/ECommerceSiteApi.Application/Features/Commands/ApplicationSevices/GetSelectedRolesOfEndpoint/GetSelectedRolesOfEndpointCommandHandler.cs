
using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.EndpointDtos;
using ECommerceSiteApi.Application.Repositories;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationSevices.GetSelectedRolesOfEndpoint;

public class GetSelectedRolesOfEndpointCommandHandler : IRequestHandler<GetSelectedRolesOfEndpointCommandRequest, GetSelectedRolesOfEndpointCommandResponse>
{
    private readonly IEndpointReadRepository _endpointReadRepoistory;

    public GetSelectedRolesOfEndpointCommandHandler(IEndpointReadRepository endpointReadRepoistory)
    {
        _endpointReadRepoistory = endpointReadRepoistory;
    }

    public async Task<GetSelectedRolesOfEndpointCommandResponse> Handle(GetSelectedRolesOfEndpointCommandRequest request, CancellationToken cancellationToken)
    {
        var appRoles=await _endpointReadRepoistory.GetSelectedRolesOfEndpoint(request.EndpointCode);
        return new() { CustomResponseDto =CustomResponseDto<IEnumerable<string>>.Success(200,appRoles)};
    }
}
