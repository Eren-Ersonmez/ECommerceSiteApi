using ECommerceSiteApi.Application.DTOs;

namespace ECommerceSiteApi.Application.Features.Queries.ApplicationUsers.GetUsersRoles;

public class GetUsersRolesResponse
{
    public CustomResponseDto<IList<string>> CustomResponseDto { get; set; }
}