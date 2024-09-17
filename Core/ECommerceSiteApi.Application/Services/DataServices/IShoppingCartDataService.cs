using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.ShoppingCartDtos;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Services.DataServices;

public interface IShoppingCartDataService: IDataService<ShoppingCart,ShoppingCartDto>
{
    Task<CustomResponseDto<IEnumerable<ShoppingCartDto>>> GetUsersShoppingCartsAsync();
    Task<CustomResponseDto<bool>> UpdateShoppingCartsAsync(ShoppingCartUpdateDto shoppingCart);
}
