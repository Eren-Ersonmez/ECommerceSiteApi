
namespace ECommerceSiteApi.Application.DTOs.ConfigurationDtos;

public class Menu
{
    public string MenuName { get; set; }
    public List<Action> Actions { get; set; } = new();
}
