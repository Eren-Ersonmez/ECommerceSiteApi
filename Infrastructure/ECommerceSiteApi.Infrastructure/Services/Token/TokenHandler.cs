

using ECommerceSiteApi.Application.Services.Token;
using ECommerceSiteApi.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ECommerceSiteApi.Infrastructure.Services.Token;

public class TokenHandler : ITokenHandler
{
    IConfiguration _configuration;

    public TokenHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Application.DTOs.Token CreateAccessToken(int minutes,ApplicationUser user)
    {
        Application.DTOs.Token token = new();
        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Token")["SecretKey"]));

        SigningCredentials signingCredentials = new(securityKey,SecurityAlgorithms.HmacSha256);

        token.Expiration=DateTime.UtcNow.AddMinutes(minutes);

        JwtSecurityToken securityToken = new JwtSecurityToken(
            audience: _configuration["Token:Audience"],
            issuer: _configuration["Token:Issuer"],
            expires: token.Expiration,
            notBefore: DateTime.UtcNow,
            signingCredentials: signingCredentials,
            claims:new List<Claim>() 
            {
                new(ClaimTypes.Name,user.UserName)
            }
            
            );
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        token.AccessToken =handler.WriteToken(securityToken);
        token.RefreshToken= CreateRefreshToken();
        return token;
    }

    public string CreateRefreshToken()
    {
        Byte[] number= new Byte[32];
        using RandomNumberGenerator random=RandomNumberGenerator.Create();
        random.GetBytes(number);
        return Convert.ToBase64String(number);
    }
}
