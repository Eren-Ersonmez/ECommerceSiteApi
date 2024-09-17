using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.OrderDtos;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Application.Services.HubServices;
using ECommerceSiteApi.Application.Services.MailServices;
using ECommerceSiteApi.Domain.Constants;
using ECommerceSiteApi.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSiteApi.Application.Features.Commands.Orders.AddOrder;

public class AddOrderCommandHandler : IRequestHandler<AddOrderCommandRequest, AddOrderCommandResponse>
{
    private readonly IDataService<Order,OrderDto> _orderService;
    private readonly IOrderHubService _orderHubService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<Domain.Models.ApplicationUser> _userManager;
    private readonly IMailService _mailService;

    public AddOrderCommandHandler(IDataService<Order, OrderDto> orderService, IOrderHubService orderHubService, IHttpContextAccessor httpContextAccessor, UserManager<Domain.Models.ApplicationUser> userManager,IMailService mailService)
    {
        _orderService = orderService;
        _orderHubService = orderHubService;
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
        _mailService = mailService;
    }

    public async Task<AddOrderCommandResponse> Handle(AddOrderCommandRequest request, CancellationToken cancellationToken)
    {
        string? userName = _httpContextAccessor.HttpContext.User.Identity?.Name;
        if (userName != null) 
        {
            Domain.Models.ApplicationUser? user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            OrderCreateDto dto = new OrderCreateDto()
            {
                ApplicationUserId = user.Id,
                OrderStatus=OrderStatus.WaitingForOrderConfirmation,
                OrderTotal=request.OrderTotal,
                AddressId=request.AddressId,
                CreditCardId=request.CreditCardId,
                OrderDetailIds=request.OrderDetailIds,
            };
            await _orderHubService.OrderAddedMessageAsync("Yeni bir sipariş var");
            AddOrderCommandResponse response= new AddOrderCommandResponse() {CustomResponseDto= await _orderService.AddAsync(dto)};
            await _mailService.SendMailAsync(user.Email,"Sipariş Durumu","<strong>Siparişiniz alınmıştır.</strong>");
            return response;
            
        }
        else
        {
            return new() { CustomResponseDto =CustomResponseDto<OrderDto>.Fail(400,"User not found")};
        }


       
    }
   
}
