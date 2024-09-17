
namespace ECommerceSiteApi.Application.Services.HubServices;

public interface IProductHubService
{
    Task ProductAddedMessageAsync(string message);
}
