using ECommerceSiteApi.Application.DTOs;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.UpdatePassword;

public class UpdatePasswordCommandResponse
{
    public CustomResponseDto<NoContentDto> CustomResponseDto { get; set; }
}