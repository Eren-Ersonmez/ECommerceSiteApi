using ECommerceSiteApi.Application.DTOs;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.PasswordReset
{
    public class PasswordResetCommandResponse
    {
        public CustomResponseDto<NoContentDto> CustomResponseDto { get; set; }
    }
}