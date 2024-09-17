using AutoMapper;
using Azure.Core;
using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.ApplicationUserDtos;
using ECommerceSiteApi.Application.DTOs.EndpointDtos;
using ECommerceSiteApi.Application.Helpers;
using ECommerceSiteApi.Application.Repositories;
using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Application.Services.MailServices;
using ECommerceSiteApi.Application.Services.Token;
using ECommerceSiteApi.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSiteApi.Infrastructure.Services.DataServices;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IReadRepository<Domain.Models.Endpoint> _endpointReadRepository;
    private readonly ITokenHandler _tokenHandler;
    private readonly IMailService _mailService;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _contextAccessor;
    public UserService(UserManager<ApplicationUser> userManager,ITokenHandler tokenHandler,IMailService mailService,IMapper mapper, IReadRepository<Domain.Models.Endpoint> endpointReadRepository,IHttpContextAccessor contextAccessor)
    {
        _userManager = userManager;
        _tokenHandler = tokenHandler;
        _mailService = mailService;
        _mapper = mapper;
        _endpointReadRepository = endpointReadRepository;
        _contextAccessor = contextAccessor;
    }

    public async Task<CustomResponseDto<bool>> AddUserAsync(ApplicationUserCreateDto dto)
    {
        try
        {

            var result = await _userManager.CreateAsync(new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                Name = dto.Name,
                Surname = dto.SurName,
                Email = dto.Email,
                UserName = dto.Email,
            }, dto.Password);
            List<string> errors = new();
            if (result.Succeeded)
            {
                return CustomResponseDto<bool>.Success(201, true);
            }
            else
            {
                foreach (var value in result.Errors)
                {
                    errors.Add(value.Description);
                }
            }
            return CustomResponseDto<bool>.Fail(500, errors);
        }
        catch (Exception ex)
        {
            return CustomResponseDto<bool>.Fail(500, ex.Message);

        }
    }

    public async Task PasswordResetAsync(string email)
    {
        ApplicationUser user= await _userManager.FindByEmailAsync(email);
        if (user != null) 
        { 
          string resetToken= await _userManager.GeneratePasswordResetTokenAsync(user);
          resetToken=CustomEncoders.UrlEncode(resetToken);
          await _mailService.SendPasswordResetMailAsync(email, user.Id,resetToken);
        }
        throw new NotImplementedException();
    }

    public async Task RefreshUpdateTokenAsync(string refreshToken,ApplicationUser user, DateTime accessTokenDate,int addOnAccessToken)
    {
       user.RefreshToken = refreshToken;
       user.RefreshTokenEndDate = accessTokenDate.AddMinutes(addOnAccessToken);
       await _userManager.UpdateAsync(user);
    }

    public async Task<CustomResponseDto<NoContentDto>> UpdatePasswordAsync(string userId,string resetToken,string newPassword)
    {
        ApplicationUser user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            resetToken = CustomEncoders.UrlDecode(resetToken);

            IdentityResult identityResult = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
            if (identityResult.Succeeded)
            {
                await _userManager.UpdateSecurityStampAsync(user);
                return CustomResponseDto<NoContentDto>.Success(200);
            }
            else
            {
                return CustomResponseDto<NoContentDto>.Fail(500, "Şifre güncellenirken beklenmeyen bir hata oluştu");
            }
        }
        return CustomResponseDto<NoContentDto>.Fail(400, "User not found");
    }

    public async Task<CustomResponseDto<bool>> VerifyResetTokenAsync(string resetToken, string userId)
    {
        ApplicationUser user= await _userManager.FindByIdAsync(userId);
        if (user != null) 
        {    
           resetToken=CustomEncoders.UrlDecode(resetToken);
            bool result = await _userManager.VerifyUserTokenAsync (user,_userManager.Options.Tokens.PasswordResetTokenProvider,"ResetPassword",resetToken);
            return CustomResponseDto<bool>.Success(200, result);
        }
        return CustomResponseDto<bool>.Success(200, false);
    }
    public async Task<CustomResponseDto<IEnumerable<ApplicationUserDto>>> GetUsersAsync(Pagination pagination)
    {
        int dataTotalCount=await _userManager.Users.CountAsync();   
        var users = await _userManager.Users.Skip(pagination.Page).Take(pagination.PageSize).ToListAsync();
        var dtos=_mapper.Map<IEnumerable<ApplicationUserDto>>(users);
        return CustomResponseDto<IEnumerable<ApplicationUserDto>>.Success(200, dtos,dataTotalCount);
    }

    public async Task<CustomResponseDto<IList<string>>> GetUsersRolesAsync(string userIdOrUsername)
    {
        ApplicationUser? user = await _userManager.FindByIdAsync(userIdOrUsername);
        if (user == null) 
        {
            user=await _userManager.FindByEmailAsync(userIdOrUsername);
        }
        if (user != null)
        {
            var appRoles=await _userManager.GetRolesAsync(user);
            return CustomResponseDto<IList<string>>.Success(200, appRoles);
        }
        return CustomResponseDto<IList<string>>.Fail(400,"User Not Found"); 
    }

    public async Task<CustomResponseDto<bool>> AssignRoles(string userId, string[] roles)
    {
        ApplicationUser? user = await _userManager.FindByIdAsync(userId);
        if (user != null) 
        {
            var appRoles = await _userManager.GetRolesAsync(user);
            if (appRoles != null) 
            {
                await _userManager.RemoveFromRolesAsync(user, appRoles);
            }
           IdentityResult identityResult =await _userManager.AddToRolesAsync(user, roles);
            if (identityResult.Succeeded) 
            { 
               return CustomResponseDto<bool>.Success(201,true);
            }
            return CustomResponseDto<bool>.Fail(500, "Beklenmeyen bir hata oluştu");

        }
        return CustomResponseDto<bool>.Fail(400, "User not found");
    }

    public async Task<bool> HasRolePermissionToEndpoint(string name, string code)
    {
        var userRoles=await GetUsersRolesAsync(name);
        if (userRoles.Data.Any())
            return false;
       Domain.Models.Endpoint? endpoint= await _endpointReadRepository.DataTable.Include(x=>x.Roles).FirstOrDefaultAsync(e=>e.Code==code);
        if (endpoint == null)
            return false;
        var endpointRoles=endpoint.Roles.Select(x=>x.Name).ToList();
        foreach (var userRole in userRoles.Data)
        {
            foreach (var role in endpointRoles)
                if (userRole == role)
                    return true;
                
        }
        return false;
    }

    public async Task<CustomResponseDto<bool>> UpdatePasswordAsync(string oldPassword, string newPassword)
    {
        string? userName = _contextAccessor.HttpContext?.User.Identity?.Name;
        ApplicationUser? user=await _userManager.Users.FirstOrDefaultAsync(x=>x.UserName==userName);
        var result = await _userManager.CheckPasswordAsync(user,oldPassword);
        if (result)
        {
            IdentityResult identityResult=await _userManager.ChangePasswordAsync(user,oldPassword,newPassword);
            if (identityResult.Succeeded)
                return CustomResponseDto<bool>.Success(200,true);
            return CustomResponseDto<bool>.Fail(400,"Mevcut şifrenizi yanlış yazdınız");

        }
        return CustomResponseDto<bool>.Fail(400,"User not found");
    }

    public async Task<CustomResponseDto<bool>> UpdateUserInfoAsync(ApplicationUserUpdateDto dto)
    {
       string? userName=_contextAccessor.HttpContext?.User.Identity?.Name;
       ApplicationUser? user = await _userManager.Users.FirstOrDefaultAsync(x=>x.UserName==userName);
       user.PhoneNumber=dto.PhoneNumber;
       user.Name=dto.Name;
       user.Surname=dto.Surname;
       user.BirthDay=dto.BirthDay;
       user.Gender=dto.Gender;
       IdentityResult identityResult=await _userManager.UpdateAsync(user);
        if (identityResult.Succeeded)
            return CustomResponseDto<bool>.Success(200, true);
        else
            return CustomResponseDto<bool>.Fail(500,"Kullanıcı güncellenmedi");
       
    }
}
