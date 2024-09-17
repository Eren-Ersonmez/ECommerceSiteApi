using ECommerceSiteApi.Application.CustomAttributes;
using ECommerceSiteApi.Application.DTOs.EndpointDtos;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Reflection;

namespace ECommerceSiteApi.Api.Filters;

public class RolePermissionFilter : IAsyncActionFilter
{
    private readonly IUserService _userService;
    public RolePermissionFilter(IUserService userService)
    => _userService = userService;
    

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        string? username = context.HttpContext.User.Identity?.Name;
        if (!string.IsNullOrEmpty(username))
        {
            var descriptor=context.ActionDescriptor as ControllerActionDescriptor;
            var attribute = descriptor.MethodInfo.GetCustomAttribute(typeof(AuthorizeDefinationAttribute)) as AuthorizeDefinationAttribute;

           var httpAttribute=descriptor.MethodInfo.GetCustomAttribute(typeof(HttpMethodAttribute)) as HttpMethodAttribute;
           var code = $"{(httpAttribute !=null ? httpAttribute.HttpMethods.First():HttpMethods.Get)}.{attribute.ActionType.ToString()}.{attribute.Defination.Replace(" ","")}";

            bool hasRole = await _userService.HasRolePermissionToEndpoint(username, code);
            if (hasRole)
            {
                await next();
            }
            else
            {
                context.Result = new UnauthorizedResult();
            }
        }
        else
            await next();
        
        
    }
}