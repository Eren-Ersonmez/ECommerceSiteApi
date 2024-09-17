

using ECommerceSiteApi.Application.DTOs.ShoppingCartDtos;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ShoppingCarts.AddShoppingCarts;

public class AddShoppingCartCommandRequest:IRequest<AddShoppingCartCommandResponse>
{
    public ShoppingCartCreateDto CreateDto { get; set; } 
}
