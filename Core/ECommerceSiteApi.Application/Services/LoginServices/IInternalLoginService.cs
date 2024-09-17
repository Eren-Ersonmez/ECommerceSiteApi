

using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.Features.Commands.ApplicationUser.Login;

namespace ECommerceSiteApi.Application.Services.LoginServices;

public interface IInternalLoginService
{
    Task<CustomResponseDto<DTOs.Token>> LoginAsync(string Email,string password);
    Task<CustomResponseDto<DTOs.Token>> RefreshTokenLogin(string refreshToken);
}
