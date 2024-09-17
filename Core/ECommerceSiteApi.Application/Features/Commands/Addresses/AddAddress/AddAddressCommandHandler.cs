

using ECommerceSiteApi.Application.DTOs.AddressDtos;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSiteApi.Application.Features.Commands.Addresses.AddAddress;

public class AddAddressCommandHandler : IRequestHandler<AddAddressCommandRequest, AddAddressCommandResponse>
{
    private readonly IDataService<Address,AddressDto> _addressService;
    private readonly UserManager<Domain.Models.ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AddAddressCommandHandler(IDataService<Address, AddressDto> addressService, UserManager<Domain.Models.ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _addressService = addressService;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<AddAddressCommandResponse> Handle(AddAddressCommandRequest request, CancellationToken cancellationToken)
    {
        string? userName = _httpContextAccessor.HttpContext.User.Identity?.Name;
        if (userName != null) {
            Domain.Models.ApplicationUser? user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            AddressDto dto = new AddressDto()
            {
                AddressOwnerName = request.AddressCreateDto.AddressOwnerName,
                AddressOwnerSurname = request.AddressCreateDto.AddressOwnerSurname,
                City = request.AddressCreateDto.City,
                District = request.AddressCreateDto.District,
                Content = request.AddressCreateDto.Content,
                PhoneNumber = request.AddressCreateDto.PhoneNumber,
                PostalCode = request.AddressCreateDto.PostalCode,
                Title = request.AddressCreateDto.Title,
                ApplicationUserId = user.Id,
           
            };

            return new() { CustomResponseDto = await _addressService.AddAsync(dto)};
        }
      
        throw new Exception("User not found");
    }
}
