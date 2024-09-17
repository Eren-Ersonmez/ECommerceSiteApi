using ECommerceSiteApi.Application.DTOs.AddressDtos;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Addresses.GetAddress;

public class GetAddressQueryHandler : IRequestHandler<GetAddressQueryRequest, GetAddressQueryResponse>
{
    private readonly IDataService<Address,AddressDto> _addressService;

    public GetAddressQueryHandler(IDataService<Address, AddressDto> addressService)
    => _addressService = addressService;
    

    public async Task<GetAddressQueryResponse> Handle(GetAddressQueryRequest request, CancellationToken cancellationToken)
    => new() {CustomResponseDto= await _addressService.GetByIdAsync(request.Id) };
    
}
