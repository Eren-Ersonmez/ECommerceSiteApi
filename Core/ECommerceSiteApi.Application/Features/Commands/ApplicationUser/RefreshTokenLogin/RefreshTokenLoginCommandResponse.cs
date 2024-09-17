
using ECommerceSiteApi.Application.DTOs;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.RefreshTokenLogin;

public class RefreshTokenLoginCommandResponse
{
    public CustomResponseDto<Token> CustomResponseDto { get; set; }
}
