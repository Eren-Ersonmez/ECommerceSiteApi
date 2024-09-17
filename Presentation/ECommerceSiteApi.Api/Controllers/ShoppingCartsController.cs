using ECommerceSiteApi.Application.Constants;
using ECommerceSiteApi.Application.CustomAttributes;
using ECommerceSiteApi.Application.DTOs.ShoppingCartDtos;
using ECommerceSiteApi.Application.Enums;
using ECommerceSiteApi.Application.Features.Commands.ShoppingCarts.AddShoppingCarts;
using ECommerceSiteApi.Application.Features.Commands.ShoppingCarts.UpdateShoppingCart;
using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSiteApi.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ShoppingCartsController : CustomBaseController
    {
        private readonly IShoppingCartDataService _shoppingCartService;
        private readonly IMediator _mediator;

        public ShoppingCartsController(IShoppingCartDataService shoppingCartService,IMediator mediator)
        {
            _shoppingCartService = shoppingCartService;
            _mediator = mediator;
        }
        [HttpGet]
        [AuthorizeDefination(Menu =AuthorizeDefinationCustom.ShoppingCarts,ActionType =ActionType.Reading,Defination = "Get Shopping Carts")]
        public async Task<IActionResult> GetShoppingCarts([FromQuery] Pagination pagination)
        => CreateActionResult(await _shoppingCartService.GetAllAsync(pagination));

        [HttpGet("{id}")]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.ShoppingCarts, ActionType = ActionType.Reading, Defination = "Get Shopping Cart")]
        public async Task<IActionResult> GetShoppingCart(string id)
        => CreateActionResult(await _shoppingCartService.GetByIdAsync(id));

        [HttpGet("[action]")]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.ShoppingCarts, ActionType = ActionType.Reading, Defination = "Get Users Shopping Carts")]
        public async Task<IActionResult> GetUsersShoppingCarts()
        =>CreateActionResult(await _shoppingCartService.GetUsersShoppingCartsAsync());
       
        [HttpPost]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.ShoppingCarts, ActionType = ActionType.Writing, Defination = "Add Shopping Cart")]
        public async Task<IActionResult> AddShoppingCart([FromBody]AddShoppingCartCommandRequest request)
        => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

        [HttpDelete("{id}")]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.ShoppingCarts, ActionType = ActionType.Deleting, Defination = "Delete Shopping Cart")]
        public async Task<IActionResult> DeleteShoppingCart(string id)
        => CreateActionResult(await _shoppingCartService.DeleteAsync(id));

        [HttpPut]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.ShoppingCarts, ActionType = ActionType.Updating, Defination = "Update Shopping Cart")]
        public async Task<IActionResult> UpdateShoppingCart(UpdateShoppingCartCommandRequest request)
        => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);
    }
}
