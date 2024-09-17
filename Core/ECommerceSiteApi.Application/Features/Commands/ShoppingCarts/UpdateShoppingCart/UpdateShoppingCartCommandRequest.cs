

using ECommerceSiteApi.Application.DTOs.ShoppingCartDtos;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ShoppingCarts.UpdateShoppingCart;

public class UpdateShoppingCartCommandRequest:IRequest<UpdateShoppingCartCommandResponse>
{
    public ShoppingCartUpdateDto UpdateShoppingCart { get; set; }
}
