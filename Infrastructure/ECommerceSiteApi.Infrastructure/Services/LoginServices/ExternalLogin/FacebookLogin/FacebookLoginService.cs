using ECommerceSiteApi.Application.DTOs.FacebookDtos;
using ECommerceSiteApi.Application.Features.Commands.ApplicationUser.ExternalLogin;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Application.Services.LoginService.FacebookLogin;
using ECommerceSiteApi.Application.Services.Token;
using ECommerceSiteApi.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ECommerceSiteApi.Infrastructure.Services.LoginServices.ExternalLogin.FacebookLogin;

public class FacebookLoginService :ExternalLogin, IFacebookLoginService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public FacebookLoginService(UserManager<ApplicationUser> userManager, IConfiguration configuration, IHttpClientFactory httpClientFaktory, ITokenHandler tokenHandler,IUserService userService):base(userManager,tokenHandler,userService)
    {
        _configuration = configuration;
        _httpClient = httpClientFaktory.CreateClient();
    }

    public async Task<Application.DTOs.Token> ValidateTokenAsync(ExternalLoginCommandRequest request)
    {
        string accessTokenResponse = await _httpClient.GetStringAsync(_configuration["ExternalLogin:facebookAccessToken"]);

        FacebookAccessToken accessToken = JsonConvert.DeserializeObject<FacebookAccessToken>(accessTokenResponse);

        string validationUrl = $"https://graph.facebook.com/debug_token?input_token={request.AuthToken}&access_token={accessToken.AccessToken}";

        var response = await _httpClient.GetStringAsync(validationUrl);

        var tokenInfo = JsonConvert.DeserializeObject<FacebookTokenValidationResponse>(response);

        if (tokenInfo.Data.IsValid)
        {
            UserLoginInfo userLoginInfo = new(request.Provider, tokenInfo.Data.UserId, request.Provider);
            ApplicationUser user = await _userManager.FindByLoginAsync(userLoginInfo.LoginProvider, userLoginInfo.ProviderKey);
            return await CreateUserExternalLoginAsync(user,request.Email,request.FirstName+" "+request.LastName,userLoginInfo,45);
        }
        throw new Exception("Invalid external authentication.");
    }
}
