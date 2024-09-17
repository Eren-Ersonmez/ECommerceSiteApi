using ECommerceSiteApi.Application.DTOs;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.AssignRoles;

public class AssignRolesCommandResponse
{
    public CustomResponseDto<bool> CustomResponseDto { get; set; }
}