using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Repositories;

public interface IShoppingCartReadRepository:IReadRepository<ShoppingCart>
{
    Task<IEnumerable<ShoppingCart>> GetUsersShoppingCartsAsync(string userId);
}
