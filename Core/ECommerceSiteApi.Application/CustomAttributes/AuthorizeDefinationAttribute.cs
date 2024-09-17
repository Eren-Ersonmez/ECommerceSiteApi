

using ECommerceSiteApi.Application.Enums;

namespace ECommerceSiteApi.Application.CustomAttributes;

public class AuthorizeDefinationAttribute:Attribute
{
    public string Menu {  get; set; }   
    public string Defination { get; set; }
    public ActionType ActionType { get; set; }
}
