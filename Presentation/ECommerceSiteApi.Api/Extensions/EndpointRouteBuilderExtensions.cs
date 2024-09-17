using ECommerceSiteApi.SignalR.Hubs;

namespace ECommerceSiteApi.Api.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static void ConfigureHubs(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapHub<ProductHub>("/productsHub");
        endpoints.MapHub<OrderHub>("/ordersHub");
    }
}
