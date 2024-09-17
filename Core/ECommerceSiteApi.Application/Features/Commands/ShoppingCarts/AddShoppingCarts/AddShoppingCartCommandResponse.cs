

using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.ShoppingCartDtos;

namespace ECommerceSiteApi.Application.Features.Commands.ShoppingCarts.AddShoppingCarts;

public class AddShoppingCartCommandResponse
{
    public CustomResponseDto<ShoppingCartDto> CustomResponseDto { get; set; }
}
