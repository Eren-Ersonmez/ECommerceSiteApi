
namespace ECommerceSiteApi.Application.Services.HubServices;

public interface IOrderHubService
{
    Task OrderAddedMessageAsync(string message);
}
