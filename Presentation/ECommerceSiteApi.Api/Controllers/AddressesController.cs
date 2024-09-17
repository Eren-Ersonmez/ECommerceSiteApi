using ECommerceSiteApi.Application.Constants;
using ECommerceSiteApi.Application.CustomAttributes;
using ECommerceSiteApi.Application.DTOs.AddressDtos;
using ECommerceSiteApi.Application.Enums;
using ECommerceSiteApi.Application.Features.Commands.Addresses.AddAddress;
using ECommerceSiteApi.Application.Features.Queries.Addresses.GetAddress;
using ECommerceSiteApi.Application.Features.Queries.Addresses.GetAddresses;
using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSiteApi.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Admin")]
    public class AddressesController : CustomBaseController
    {
        private readonly IDataService<Address, AddressDto> _addressService;
        private readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public AddressesController(IDataService<Address, AddressDto> addressService, IMediator mediator, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _addressService = addressService;
            _mediator = mediator;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserAddresses()
        {
            string? userName=_contextAccessor.HttpContext?.User.Identity?.Name;
            ApplicationUser? user=await _userManager.Users.FirstOrDefaultAsync(x=>x.UserName==userName);
            var dto= await _addressService.WhereAsync(x => x.ApplicationUserId == user.Id);
            return CreateActionResult(dto);
        }

        [HttpGet]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.Addresses, ActionType = ActionType.Reading, Defination = "Get Addresses")]
        public async Task<IActionResult> GetAddresses([FromQuery]GetAddressesQueryRequest request)
        => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);
        
        [HttpGet("{id}")]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.Addresses, ActionType = ActionType.Reading, Defination = "Get Address")]
        public async Task<IActionResult> GetAddress([FromRoute]GetAddressQueryRequest request)
        => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);
        
        [HttpPost]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.Addresses, ActionType = ActionType.Writing, Defination = "Add Address")]
        public async Task<IActionResult> AddAddress(AddAddressCommandRequest request)
        => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);
        
        [HttpDelete("{id}")]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.Addresses, ActionType = ActionType.Deleting, Defination = "Delete Address")]
        public async Task<IActionResult> DeleteAddress(string id)
        {
            return CreateActionResult(await _addressService.DeleteAsync(id));
        }
        [HttpPut]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.Addresses, ActionType = ActionType.Updating, Defination = "Update Address")]
        public async Task<IActionResult> UpdateAddress(AddressUpdateDto dto)
        {
            return CreateActionResult(await (_addressService.UpdateAsync(dto)));    
        }
    }
}
