using ECommerceSiteApi.Application.Features.Commands.ApplicationUser.ExternalLogin;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Application.Services.LoginService.GoogleLogin;
using ECommerceSiteApi.Application.Services.Token;
using ECommerceSiteApi.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace ECommerceSiteApi.Infrastructure.Services.LoginServices.ExternalLogin.GoogleLogin;

public class GoogleLoginService : ExternalLogin,IGoogleLoginService
{
    private readonly IConfiguration _configuration;

    public GoogleLoginService(IConfiguration configuration, UserManager<ApplicationUser> userManager, ITokenHandler tokenHandler, IUserService userService) :base(userManager,tokenHandler, userService)
    {
        _configuration = configuration;
    }

    public async Task<Application.DTOs.Token> ValidateTokenAsync(ExternalLoginCommandRequest request)
    {
        ValidationSettings? settings = new ValidationSettings()
        {
            Audience = new List<string>()
                { _configuration["ExternalLogin:Google-Client-Id"] }
        };
        Payload payload = await ValidateAsync(request.IdToken, settings);

        UserLoginInfo userLoginInfo = new(request.Provider, payload.Subject, request.Provider);
        ApplicationUser user = await _userManager.FindByLoginAsync(userLoginInfo.LoginProvider, userLoginInfo.ProviderKey);
        return  await CreateUserExternalLoginAsync(user, payload.Email, payload.Name, userLoginInfo, 45);
       
    }
}
