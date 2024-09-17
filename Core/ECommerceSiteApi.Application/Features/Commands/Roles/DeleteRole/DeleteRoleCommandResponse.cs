using ECommerceSiteApi.Application.DTOs;

namespace ECommerceSiteApi.Application.Features.Commands.Roles.DeleteRole;

public class DeleteRoleCommandResponse
{
    public CustomResponseDto<bool> CustomResponseDto { get; set; }
}