using ECommerceSiteApi.Application.DTOs;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.VerifyResetToken;

public class VerifyResetTokenCommandResponse
{
    public CustomResponseDto<bool> CustomResponseDto { get; set; }
}