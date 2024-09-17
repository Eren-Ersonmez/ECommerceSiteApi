using ECommerceSiteApi.Application.Constants;
using ECommerceSiteApi.Application.CustomAttributes;
using ECommerceSiteApi.Application.DTOs.OrderDetailsDtos;
using ECommerceSiteApi.Application.Enums;
using ECommerceSiteApi.Application.Features.Commands.OrderDetails.AddOrderDetails;
using ECommerceSiteApi.Application.Features.Queries.OrderDetails.GetByOrderIdOrderDetails;
using ECommerceSiteApi.Application.Features.Queries.OrderDetails.GetOrderDetails;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSiteApi.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Admin")]
    public class OrderDetailsController : CustomBaseController
    {
        private readonly IMediator _mediator;
        private readonly IDataService<OrderDetails, OrderDetailsDto> _dataService;

        public OrderDetailsController(IMediator mediator, IDataService<OrderDetails, OrderDetailsDto> dataService)
        {
            _mediator = mediator;
            _dataService = dataService;
        }

        [HttpGet("{id}")]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.OrderDetails, ActionType = ActionType.Reading, Defination = "Get Order Details")]
        public async Task<IActionResult> GetOrderDetails([FromRoute]GetOrderDetailsQueryRequest request)
        => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

        [HttpGet("[action]")]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.OrderDetails, ActionType = ActionType.Reading, Defination = "Get By Order Id Order Details")]
        public async Task<IActionResult> GetByOrderIdOrderDetails([FromQuery] GetByOrderIdOrderDetailsQueryRequest request)
        => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);
        [HttpPost]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.OrderDetails, ActionType = ActionType.Writing, Defination = "Add Order Details")]
        public async Task<IActionResult> AddOrderDetails(AddOrderDetailsCommadRequest request)
        => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);
      
    }
}
