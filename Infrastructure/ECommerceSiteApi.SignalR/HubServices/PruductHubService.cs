

using ECommerceSiteApi.Application.Services.HubServices;
using ECommerceSiteApi.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace ECommerceSiteApi.SignalR.HubServices;

public class PruductHubService : IProductHubService
{
    private readonly IHubContext<ProductHub> _hubContext;

    public PruductHubService(IHubContext<ProductHub> hubContext)
    =>_hubContext = hubContext;
    

    public async Task ProductAddedMessageAsync(string message)
    =>await  _hubContext.Clients.All.SendAsync(ReceiveFunctionNames.ProductAddedMessage,message);
    
}
