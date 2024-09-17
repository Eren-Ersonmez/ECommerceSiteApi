using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationSevices.GetSelectedRolesOfEndpoint;

public class GetSelectedRolesOfEndpointCommandResponse
{
    public CustomResponseDto<IEnumerable<string>> CustomResponseDto { get; set; }
}