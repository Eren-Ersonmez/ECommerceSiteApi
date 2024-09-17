

using ECommerceSiteApi.Application.Constants;
using ECommerceSiteApi.Application.CustomAttributes;
using ECommerceSiteApi.Application.Enums;
using ECommerceSiteApi.Application.Features.Commands.Roles.AddRole;
using ECommerceSiteApi.Application.Features.Commands.Roles.DeleteRole;
using ECommerceSiteApi.Application.Features.Queries.Roles.GetRoles;
using ECommerceSiteApi.Application.Services.RoleServices;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSiteApi.Api.Controllers;

[Authorize(AuthenticationSchemes = "Admin")]
public class RolesController : CustomBaseController
{
    private readonly IMediator _mediator;
    private readonly IRoleService _roleService;

    public RolesController(IMediator mediator,IRoleService roleService)
    { 
        _mediator = mediator;
        _roleService = roleService;
    }

    [HttpGet]
    [AuthorizeDefination(Menu = AuthorizeDefinationCustom.Roles, ActionType = ActionType.Reading, Defination = "Get Roles")]
    public async Task<IActionResult> GetRoles([FromQuery] GetRolesQueryRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

    [HttpGet("[action]")]
    [AuthorizeDefination(Menu = AuthorizeDefinationCustom.Roles, ActionType = ActionType.Reading, Defination = "Get All Roles")]
    public async Task<IActionResult> GetAllRoles()
    => CreateActionResult(await _roleService.GetRolesAsync());

    [HttpPost]
    [AuthorizeDefination(Menu = AuthorizeDefinationCustom.Roles, ActionType = ActionType.Writing, Defination = "Add Role")]
    public async Task<IActionResult> AddRole(AddRoleCommandRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

    [HttpDelete("{id}")]
    [AuthorizeDefination(Menu = AuthorizeDefinationCustom.Roles, ActionType = ActionType.Deleting, Defination = "Delete Role")]
    public async Task<IActionResult> DeleteRole([FromRoute]DeleteRoleCommandRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);
    
}

