
using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.AddressDtos;

namespace ECommerceSiteApi.Application.Features.Commands.Addresses.AddAddress;

public class AddAddressCommandResponse
{
    public CustomResponseDto<AddressDto> CustomResponseDto { get; set; }
}
