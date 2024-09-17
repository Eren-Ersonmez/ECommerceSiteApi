

using ECommerceSiteApi.Application.DTOs;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.Login;

public class LoginCommandResponse
{
    public CustomResponseDto<Token> CustomResponseDto { get; set; }
}
