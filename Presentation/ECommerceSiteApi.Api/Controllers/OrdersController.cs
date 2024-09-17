using Azure.Identity;
using ECommerceSiteApi.Application.Constants;
using ECommerceSiteApi.Application.CustomAttributes;
using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.OrderDtos;
using ECommerceSiteApi.Application.Enums;
using ECommerceSiteApi.Application.Features.Commands.Orders.AddOrder;
using ECommerceSiteApi.Application.Features.Commands.Orders.UpdateOrderStatus;
using ECommerceSiteApi.Application.Features.Queries.Orders.GetOrder;
using ECommerceSiteApi.Application.Features.Queries.Orders.GetOrders;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSiteApi.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Admin")]
    public class OrdersController : CustomBaseController
    {
        private readonly IOrderDataService _orderService;
        private readonly IMediator _mediator;
        private IHttpContextAccessor _contextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(IOrderDataService orderService,IMediator mediator,IHttpContextAccessor contextAccessor,UserManager<ApplicationUser> userManager)
        {
            _orderService = orderService;
            _mediator = mediator;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        [HttpGet]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.Orders, ActionType = ActionType.Reading, Defination = "Get Orders")]
        public async Task<IActionResult> GetOrders([FromQuery] GetOrdersQueryRequest request)
        => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserOrders()
        {
            string? userName=_contextAccessor.HttpContext?.User.Identity?.Name;
            var user=await _userManager.Users.FirstOrDefaultAsync(x=>x.UserName==userName);
            var orders = await _orderService.WhereAsync(x=>x.ApplicationUserId==user.Id);
            return CreateActionResult(orders);
        }

        [HttpGet("{id}")]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.Orders, ActionType = ActionType.Reading, Defination = "Get Order")]
        public async Task<IActionResult> GetOrder([FromRoute]GetOrderQueryRequest request)
        => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

        [HttpPost]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.Orders, ActionType = ActionType.Writing, Defination = "Add Order")]
        public async Task<IActionResult> AddOrder(AddOrderCommandRequest request)
        => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

        [HttpDelete("{id}")]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.Orders, ActionType = ActionType.Deleting, Defination = "Delete Order")]
        public async Task<IActionResult> DeleteOrder(string id)
        => CreateActionResult(await _orderService.DeleteAsync(id));

        [HttpPut]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.Orders, ActionType = ActionType.Updating, Defination = "Update Order")]
        public async Task<IActionResult> UpdateOrder(OrderUpdateDto dto)
        => CreateActionResult(await _orderService.UpdateAsync(dto));

        [HttpPut("[action]")]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.Orders, ActionType = ActionType.Updating, Defination = "UpdateOrderStatus")]
        public async Task<IActionResult> UpdateOrderStatus(UpdateOrderStatusCommandRequest request)
        => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);
    }
}
