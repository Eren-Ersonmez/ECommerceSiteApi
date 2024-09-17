using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.ShoppingCartDtos;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace ECommerceSiteApi.Application.Features.Commands.ShoppingCarts.AddShoppingCarts;

public class AddShoppingCartCommandHandler : IRequestHandler<AddShoppingCartCommandRequest, AddShoppingCartCommandResponse>
{
    private readonly IDataService<ShoppingCart,ShoppingCartDto> _dataService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<Domain.Models.ApplicationUser> _userManager;

    public AddShoppingCartCommandHandler(IDataService<ShoppingCart, ShoppingCartDto> dataService,IHttpContextAccessor httpContextAccessor, UserManager<Domain.Models.ApplicationUser> userManager)
    {
        _dataService = dataService;
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
    }

    public async Task<AddShoppingCartCommandResponse> Handle(AddShoppingCartCommandRequest request, CancellationToken cancellationToken)
    {
       var isThere = await _dataService.AnyAsync(x=>x.ProductId==request.CreateDto.ProductId);
        if (!isThere.Data)
        {
            string? userName = _httpContextAccessor.HttpContext.User.Identity?.Name;
            if (userName != null)
            {
                Domain.Models.ApplicationUser? user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userName);
                ShoppingCartDto shoppingCart = new ShoppingCartDto
                {
                    ApplicationUserId = user.Id,
                    Count = request.CreateDto.Count,
                    Price = request.CreateDto.Price,
                    ProductId = request.CreateDto.ProductId,

                };
                return new() { CustomResponseDto = await _dataService.AddAsync(shoppingCart) };
            }
            return new() { CustomResponseDto = CustomResponseDto<ShoppingCartDto>.Fail(500, "User not found") };
        }
        var cart = await _dataService.WhereAsync(x => x.ProductId == request.CreateDto.ProductId);
        cart.Data.First().Count += 1;
        await _dataService.UpdateAsync(cart.Data.First());
        return new() {CustomResponseDto=CustomResponseDto<ShoppingCartDto>.Success(200)};
    }
}
