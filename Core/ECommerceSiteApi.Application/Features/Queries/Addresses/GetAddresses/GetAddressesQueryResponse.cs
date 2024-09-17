using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.AddressDtos;

namespace ECommerceSiteApi.Application.Features.Queries.Addresses.GetAddresses;

public class GetAddressesQueryResponse
{
   public CustomResponseDto<IEnumerable<AddressDto>> CustomResponseDto { get; set; }
}
