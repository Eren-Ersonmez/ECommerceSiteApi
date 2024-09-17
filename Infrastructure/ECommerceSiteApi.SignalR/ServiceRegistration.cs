using ECommerceSiteApi.Application.Services.HubServices;
using ECommerceSiteApi.SignalR.HubServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SignalR;

namespace ECommerceSiteApi.SignalR;

public static class ServiceRegistration
{
    public static void AddSignalRService(this IServiceCollection services)
    {
        services.AddScoped<IProductHubService,PruductHubService>();
        services.AddScoped<IOrderHubService,OrderHubService>();
        services.AddSignalR();
    }
}
