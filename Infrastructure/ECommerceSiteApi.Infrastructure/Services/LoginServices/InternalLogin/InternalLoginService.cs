using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.Features.Commands.ApplicationUser.Login;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Application.Services.LoginServices;
using ECommerceSiteApi.Application.Services.Token;
using ECommerceSiteApi.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSiteApi.Infrastructure.Services.LoginServices.InternalLogin;

public class InternalLoginService : IInternalLoginService
{
    private readonly UserManager<ECommerceSiteApi.Domain.Models.ApplicationUser> _userManager;
    private readonly SignInManager<ECommerceSiteApi.Domain.Models.ApplicationUser> _signInManager;
    private readonly ITokenHandler _tokenHandler;
    private readonly IUserService _userService;

    public InternalLoginService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenHandler tokenHandler,IUserService userService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenHandler = tokenHandler;
        _userService = userService;
    }

    public async Task<CustomResponseDto<Application.DTOs.Token>> LoginAsync(string email,string password)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            return CustomResponseDto<ECommerceSiteApi.Application.DTOs.Token>.Fail(401, "E posta veya şifre hatalı");
        }
        var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
        if (result.Succeeded)
        {
            ECommerceSiteApi.Application.DTOs.Token token = _tokenHandler.CreateAccessToken(45,user);
            await _userService.RefreshUpdateTokenAsync(token.RefreshToken,user,token.Expiration,15);
            return   CustomResponseDto<ECommerceSiteApi.Application.DTOs.Token>.Success(201, token);
        }

        return  CustomResponseDto<ECommerceSiteApi.Application.DTOs.Token>.Fail(401, "E posta veya şifre hatalı");
        
    }

    public async Task<CustomResponseDto<Application.DTOs.Token>> RefreshTokenLogin(string refreshToken)
    {
        ApplicationUser user= await _userManager.Users.FirstOrDefaultAsync(u=>u.RefreshToken==refreshToken);
        if (user != null)
        {
            if (user.RefreshTokenEndDate>DateTime.UtcNow)
            {
                Application.DTOs.Token token=_tokenHandler.CreateAccessToken(15, user);
                await _userService.RefreshUpdateTokenAsync(token.RefreshToken,user,token.Expiration,15);
                return CustomResponseDto<Application.DTOs.Token>.Success(201,token);
            }
            return CustomResponseDto<Application.DTOs.Token>.Fail(400, "Refresh token süresi geçmiş");
        }
        return CustomResponseDto<Application.DTOs.Token>.Fail(400, "User not found");
    }
}
