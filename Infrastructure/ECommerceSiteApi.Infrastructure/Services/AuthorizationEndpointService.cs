
using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.ConfigurationDtos;
using ECommerceSiteApi.Application.DTOs.EndpointDtos;
using ECommerceSiteApi.Application.DTOs.MenuDtos;
using ECommerceSiteApi.Application.Repositories;
using ECommerceSiteApi.Application.Services;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Application.UnitOfWorks;
using ECommerceSiteApi.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSiteApi.Infrastructure.Services;

public class AuthorizationEndpointService : IAuthorizationEndpointService
{
    private readonly IConfigurationService _configurationService;
    private readonly IDataService<Endpoint,EndpointDto> _endpointService;
    private readonly IDataService<Domain.Models.Menu,MenuDto> _menuService;
    private readonly IReadRepository<Endpoint> _endpointReadRepository;
    private readonly IWriteRepository<Endpoint> _endpointWriteRepository;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly IUnitOfWork _unitOfWork;

    public AuthorizationEndpointService(IConfigurationService configurationService,IDataService<Endpoint,EndpointDto> endpointService, IDataService<Domain.Models.Menu, MenuDto> menuService,RoleManager<AppRole> roleManager,IUnitOfWork unitOfWork,IReadRepository<Endpoint> endpointReadRepository,IWriteRepository<Endpoint> endpointWriteRepository)
    {
        _configurationService = configurationService;
        _endpointService = endpointService;
        _menuService = menuService;
        _roleManager = roleManager;
        _unitOfWork = unitOfWork;
        _endpointWriteRepository = endpointWriteRepository;
        _endpointReadRepository = endpointReadRepository;
    }

    public async Task<CustomResponseDto<bool>> AssignRoleEndpointAsync(string[] roles, string EndpointCode, Type type, string menu)
    {
        List<AppRole> appRoles = null;
        appRoles = await _roleManager.Roles.Where(r => roles.Contains(r.Name)).ToListAsync();
        CustomResponseDto<MenuDto> _menu = await _menuService.GetSingleValueAsync(m => m.Name == menu,false);
        if (_menu.Data == null)
        {
            _menu = await _menuService.AddAsync(new MenuCreateDto { Name = menu });
            if (_menu.Data == null)
            {
                return CustomResponseDto<bool>.Fail(404,"Menü oluşturulamadı.");
            }
        }

        CustomResponseDto<EndpointDto> _endpoint = await _endpointService.GetSingleValueAsync(x => x.Code == EndpointCode,false);
        if (_endpoint.Data == null)
        {
            var action = _configurationService.GetAuthorizeDefinationEndpoints(type)
                            .FirstOrDefault(x => x.MenuName == menu)?.Actions
                            .FirstOrDefault(e => e.Code == EndpointCode);

            if (action != null)
            {
                _endpoint = await _endpointService.AddAsync(new EndpointCreateDto
                {
                    Code = EndpointCode,
                    ActionType = action.ActionType,
                    Definition = action.Defination,
                    HttpType = action.HttpType,
                    MenuId=_menu.Data.Id,
                    Roles=appRoles
                });
                return CustomResponseDto<bool>.Success(201, true);
            }
            
        }
        return CustomResponseDto<bool>.Success(201, true);

    }

    public async Task<CustomResponseDto<bool>> AssignRoleEndpointAsync(string[] roles, string EndpointCode)
    {
        Endpoint? _endpoint = await _endpointReadRepository.DataTable.Include(e => e.Roles).FirstOrDefaultAsync(x=>x.Code==EndpointCode);
        if (_endpoint != null) 
        {
            foreach (var role in _endpoint.Roles)
                _endpoint.Roles.Remove(role);

            var appRoles = await _roleManager.Roles.Where(r => roles.Contains(r.Name)).ToListAsync();

            foreach (var role in appRoles)
                _endpoint.Roles.Add(role);

            await _unitOfWork.CommitAsync();
        }
        return CustomResponseDto<bool>.Fail(400, "Endpoint not found");
    }
}
