

using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Application.Services.RoleServices;
using ECommerceSiteApi.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSiteApi.Infrastructure.Services;

public class RoleService : IRoleService
{
    private readonly RoleManager<AppRole> _roleManager;

    public RoleService(RoleManager<AppRole> roleManager)
    => _roleManager = roleManager;

    public async Task<CustomResponseDto<bool>> CreateRoleAsync(string roleName)
    {
        IdentityResult identityResult = await _roleManager.CreateAsync(new() {Id=Guid.NewGuid().ToString() ,Name = roleName });
        bool data= identityResult.Succeeded;
        return CustomResponseDto<bool>.Success(201,data);
    }

    public async Task<CustomResponseDto<bool>> DeleteRoleAsync(string id)
    {
        IdentityResult identityResult = await _roleManager.DeleteAsync(new() { Id=id});
        bool data = identityResult.Succeeded;
        return CustomResponseDto<bool>.Success(200, data);
    }

    public async Task<CustomResponseDto<IEnumerable<AppRole>>> GetRolesAsync(Pagination pagination)
    {
        int dataTotalCount = _roleManager.Roles.Count();
        var data= await _roleManager.Roles.Skip(pagination.Page).Take(pagination.PageSize).ToListAsync();
        return CustomResponseDto<IEnumerable<AppRole>>.Success(200, data,dataTotalCount);
    }

    public async Task<CustomResponseDto<IEnumerable<AppRole>>> GetRolesAsync()
    {
        var data = await _roleManager.Roles.ToListAsync();
        return CustomResponseDto<IEnumerable<AppRole>>.Success(200, data);
    }

    public async Task<CustomResponseDto<bool>> UpdateRoleAsync(string id, string roleName)
    {
        IdentityResult identityResult = await _roleManager.UpdateAsync(new() { Id = id, Name = roleName });
        bool data = identityResult.Succeeded;
        return CustomResponseDto<bool>.Success(200, data);
    }

}
