using Microsoft.Extensions.DependencyInjection;

namespace ECommerceSiteApi.Application;

public static class ServiceRegistration
{
    public static void AddApplicationService(this IServiceCollection services) 
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
    }
}
