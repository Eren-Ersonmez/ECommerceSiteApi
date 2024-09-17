using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.AddressDtos;

namespace ECommerceSiteApi.Application.Features.Queries.Addresses.GetAddress;

public class GetAddressQueryResponse
{
    public CustomResponseDto<AddressDto> CustomResponseDto { get; set; }
}
