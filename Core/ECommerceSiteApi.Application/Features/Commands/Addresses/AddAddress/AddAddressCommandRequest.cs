

using ECommerceSiteApi.Application.DTOs.AddressDtos;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.Addresses.AddAddress;

public class AddAddressCommandRequest:IRequest<AddAddressCommandResponse>
{
    public AddressCreateDto AddressCreateDto { get; set; }
}
