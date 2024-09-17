
using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Application.DTOs.AddressDtos;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Addresses.GetAddresses;

public class GetAddressesQueryHandler : IRequestHandler<GetAddressesQueryRequest, GetAddressesQueryResponse>
{
    private readonly IDataService<Address,AddressDto> _addressService;

    public GetAddressesQueryHandler(IDataService<Address, AddressDto> addressService)
    => _addressService = addressService;
    

    public async Task<GetAddressesQueryResponse> Handle(GetAddressesQueryRequest request, CancellationToken cancellationToken)
    => new() {CustomResponseDto= await _addressService.GetAllAsync(new Pagination { Page = request.Page, PageSize = request.PageSize }) };
    
        
}
