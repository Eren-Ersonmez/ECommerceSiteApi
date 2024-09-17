using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.ApplicationUserDtos;
using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Services.DataServices;

public interface IUserService
{
    Task<CustomResponseDto<bool>> AddUserAsync(ApplicationUserCreateDto dto);
    Task RefreshUpdateTokenAsync(string refreshToken,ApplicationUser user,DateTime accessTokenDate, int addOnAccessToken);
    Task PasswordResetAsync(string email);
    Task<CustomResponseDto<bool>> VerifyResetTokenAsync(string resetToken,string userId);
    Task<CustomResponseDto<NoContentDto>> UpdatePasswordAsync(string userId,string resetToken,string newPassword);
    Task<CustomResponseDto<bool>> UpdatePasswordAsync(string oldPassword, string newPassword);
    Task<CustomResponseDto<IEnumerable<ApplicationUserDto>>> GetUsersAsync(Pagination pagination);
    Task<CustomResponseDto<IList<string>>> GetUsersRolesAsync(string userIdOrUsername);
    Task<CustomResponseDto<bool>> AssignRoles(string userId, string[] roles);
    Task<bool> HasRolePermissionToEndpoint(string name,string code);
    Task<CustomResponseDto<bool>> UpdateUserInfoAsync(ApplicationUserUpdateDto dto);
}
