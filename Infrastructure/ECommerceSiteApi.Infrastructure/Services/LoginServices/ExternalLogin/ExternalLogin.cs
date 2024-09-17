

using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Application.Services.LoginServices;
using ECommerceSiteApi.Application.Services.Token;
using ECommerceSiteApi.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace ECommerceSiteApi.Infrastructure.Services.LoginServices.ExternalLogin;

public class ExternalLogin : IExternalLogin
{
    protected readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenHandler _tokenHandler;
    private readonly IUserService _userService;

    public ExternalLogin(UserManager<ApplicationUser> userManager, ITokenHandler tokenHandler,IUserService userService)
    {
        _userManager = userManager;
        _tokenHandler = tokenHandler;
        _userService = userService;
    }

    public async Task<Application.DTOs.Token> CreateUserExternalLoginAsync(ApplicationUser user,string email,string name,UserLoginInfo userLoginInfo, int accessTokenLifeTime)
    {
        bool result = user != null;
        if (user == null)
        {
            user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = email,
                    UserName = email,
                    Name = name.Split(' ')[0],
                    Surname = name.Substring(name.LastIndexOf(' ') + 1),
                    PhoneNumber = " "
                };
                IdentityResult createResult = await _userManager.CreateAsync(user);
                result = createResult.Succeeded;
            }
        }

        if (result)
            await _userManager.AddLoginAsync(user, userLoginInfo);
        else
            throw new Exception("Invalid external authentication.");

        Application.DTOs.Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime,user);
        await _userService.RefreshUpdateTokenAsync(token.RefreshToken,user,token.Expiration,15);
        return token;
    }
}
