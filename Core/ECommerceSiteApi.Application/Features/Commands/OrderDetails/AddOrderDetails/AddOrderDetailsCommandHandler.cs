using ECommerceSiteApi.Application.DTOs.OrderDetailsDtos;
using ECommerceSiteApi.Application.Services.DataServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.OrderDetails.AddOrderDetails;

public class AddOrderDetailsCommandHandler : IRequestHandler<AddOrderDetailsCommadRequest, AddOrderDetailsCommandResponse>
{
    private readonly IDataService<Domain.Models.OrderDetails, OrderDetailsDto> _dataService;

    public AddOrderDetailsCommandHandler(IDataService<Domain.Models.OrderDetails, OrderDetailsDto> dataService)
    => _dataService = dataService;
    

    public async Task<AddOrderDetailsCommandResponse> Handle(AddOrderDetailsCommadRequest request, CancellationToken cancellationToken)
    => new() {CustomResponseDto = await _dataService.AddAsync(request.CreateDto)};

    
}
