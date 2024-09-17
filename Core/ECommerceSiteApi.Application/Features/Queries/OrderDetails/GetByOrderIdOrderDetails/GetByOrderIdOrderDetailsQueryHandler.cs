
using ECommerceSiteApi.Application.DTOs.OrderDetailsDtos;
using ECommerceSiteApi.Application.Services.DataServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.OrderDetails.GetByOrderIdOrderDetails;

public class GetByOrderIdOrderDetailsQueryHandler : IRequestHandler<GetByOrderIdOrderDetailsQueryRequest, GetByOrderIdOrderDetailsQueryResponse>
{
    private readonly IOrderDetailsDataService _dataService;

    public GetByOrderIdOrderDetailsQueryHandler(IOrderDetailsDataService dataService)
    {
        _dataService = dataService;
    }

    public async Task<GetByOrderIdOrderDetailsQueryResponse> Handle(GetByOrderIdOrderDetailsQueryRequest request, CancellationToken cancellationToken)
    => new() {CustomResponseDto = await _dataService.GetByOrderIdOrderDetailsAsync(request.OrderId) };
    
}
