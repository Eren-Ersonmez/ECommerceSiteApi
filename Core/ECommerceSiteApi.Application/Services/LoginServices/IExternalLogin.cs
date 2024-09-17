

using ECommerceSiteApi.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace ECommerceSiteApi.Application.Services.LoginServices;

public interface IExternalLogin
{
    Task<DTOs.Token> CreateUserExternalLoginAsync(ApplicationUser user, string email, string name, UserLoginInfo userLoginInfo, int accessTokenLifeTime);
}
