using ECommerceSiteApi.Application.DTOs.OrderDetailsDtos;
using ECommerceSiteApi.Application.Services.DataServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.OrderDetails.GetOrderDetails;

public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQueryRequest, GetOrderDetailsQueryResponse>
{
    private readonly IDataService<Domain.Models.OrderDetails, OrderDetailsDto> _dataService;
    public async Task<GetOrderDetailsQueryResponse> Handle(GetOrderDetailsQueryRequest request, CancellationToken cancellationToken)
    => new() {CustomResponseDto = await _dataService.GetByIdAsync(request.Id) };
    
}
