
using ECommerceSiteApi.Application.DTOs;
using Microsoft.AspNetCore.Identity;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.AddApplicationUser;

public class AddApplicationUserCommandResponse
{
    public CustomResponseDto<bool> CustomResponseDto { get; set; }
}
