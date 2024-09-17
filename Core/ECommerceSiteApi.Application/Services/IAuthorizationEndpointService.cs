

using ECommerceSiteApi.Application.DTOs;

namespace ECommerceSiteApi.Application.Services;

public interface IAuthorizationEndpointService
{
    Task<CustomResponseDto<bool>> AssignRoleEndpointAsync(string[] roles,string EndpointCode,Type type,string menu);
    Task<CustomResponseDto<bool>> AssignRoleEndpointAsync(string[] roles, string EndpointCode);
}
