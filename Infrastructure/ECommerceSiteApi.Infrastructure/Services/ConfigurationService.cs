

using ECommerceSiteApi.Application.CustomAttributes;
using ECommerceSiteApi.Application.DTOs.ConfigurationDtos;
using ECommerceSiteApi.Application.Enums;
using ECommerceSiteApi.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Reflection;

namespace ECommerceSiteApi.Infrastructure.Services;

public class ConfigurationService : IConfigurationService
{
    public List<Menu> GetAuthorizeDefinationEndpoints(Type assemblyType)
    {
        Assembly assembly=Assembly.GetAssembly(assemblyType);
        var controllers=assembly.GetTypes().Where(x=>x.IsAssignableTo(typeof(ControllerBase)));
        List<Menu> menus = new List<Menu>();
        if (controllers!=null)
        {
            foreach (var controller in controllers)
            {
                var actions = controller.GetMethods().Where(x => x.IsDefined(typeof(AuthorizeDefinationAttribute)));
                if (actions!=null)
                {
                    foreach(var action in actions)
                    {
                        var attributes=action.GetCustomAttributes(true);
                        if (attributes!=null) 
                        { 
                            Menu menu=null;
                          var authorizeDefinationAttribute=attributes.FirstOrDefault(a=>a.GetType()==typeof(AuthorizeDefinationAttribute))as AuthorizeDefinationAttribute;
                            if (!menus.Any(m=>m.MenuName==authorizeDefinationAttribute.Menu))
                            {
                                menu=new Menu() {MenuName=authorizeDefinationAttribute.Menu };
                                menus.Add(menu);
                            }
                            else
                            {
                                menu = menus.FirstOrDefault(x=>x.MenuName== authorizeDefinationAttribute.Menu);
                                Application.DTOs.ConfigurationDtos.Action _action = new() 
                                {
                                   ActionType=Enum.GetName(typeof(ActionType),authorizeDefinationAttribute.ActionType),
                                   Defination=authorizeDefinationAttribute.Defination,
                                   
                                };
                                var httpAttribute = attributes.FirstOrDefault(x => x.GetType().IsAssignableTo(typeof(HttpMethodAttribute))) as HttpMethodAttribute;
                                if (httpAttribute != null)
                                {
                                    _action.HttpType = httpAttribute.HttpMethods.First();
                                }
                                else
                                {
                                    _action.HttpType = HttpMethods.Get;
                                }
                                _action.Code = $"{_action.HttpType}.{_action.ActionType}.{_action.Defination.Replace(" ", "")}";
                                menu.Actions.Add(_action);
                            }
                        }
                    }
                }
            }
        }

        return menus; ;
    }
}
