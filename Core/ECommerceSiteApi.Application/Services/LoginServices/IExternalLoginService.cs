

using ECommerceSiteApi.Application.Features.Commands.ApplicationUser.ExternalLogin;

namespace ECommerceSiteApi.Application.Services.LoginServices;

public interface IExternalLoginService
{
    Task<DTOs.Token> ValidateTokenAsync(ExternalLoginCommandRequest request);
}
