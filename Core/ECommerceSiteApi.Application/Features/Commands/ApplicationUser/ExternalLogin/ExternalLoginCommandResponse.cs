

using ECommerceSiteApi.Application.DTOs;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.ExternalLogin;

public class ExternalLoginCommandResponse
{
    public CustomResponseDto<Token> CustomResponseDto { get; set; }  
}
