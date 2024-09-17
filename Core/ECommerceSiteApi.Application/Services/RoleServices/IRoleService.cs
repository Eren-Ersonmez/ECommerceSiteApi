
using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Services.RoleServices;

public interface IRoleService
{
    Task<CustomResponseDto<IEnumerable<AppRole>>> GetRolesAsync(Pagination pagination);
    Task<CustomResponseDto<IEnumerable<AppRole>>> GetRolesAsync();
    Task<CustomResponseDto<bool>> CreateRoleAsync(string roleName);
    Task<CustomResponseDto<bool>> DeleteRoleAsync(string id);
    Task<CustomResponseDto<bool>> UpdateRoleAsync(string id,string roleName);
}
