using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Services.Token;

public interface ITokenHandler
{
    DTOs.Token CreateAccessToken(int minutes,ApplicationUser user);

    string CreateRefreshToken();
}
