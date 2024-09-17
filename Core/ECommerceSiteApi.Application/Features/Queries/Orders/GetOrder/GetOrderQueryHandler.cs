

using ECommerceSiteApi.Application.Services.DataServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Orders.GetOrder;

public class GetOrderQueryHandler : IRequestHandler<GetOrderQueryRequest, GetOrderQueryResponse>
{
    private readonly IOrderDataService _orderDataService;

    public GetOrderQueryHandler(IOrderDataService orderDataService)
    => _orderDataService = orderDataService;
    

    public async Task<GetOrderQueryResponse> Handle(GetOrderQueryRequest request, CancellationToken cancellationToken)
    => new() {CustomResponseDto= await _orderDataService.GetOrderWithModelsAsync(request.Id)};
    
}
