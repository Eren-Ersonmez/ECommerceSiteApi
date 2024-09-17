using ECommerceSiteApi.Application.Repositories;
using ECommerceSiteApi.Domain.Models;
using ECommerceSiteApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSiteApi.Persistence.Repositories;

public class ShoppingCartReadRepository : ReadRepository<ShoppingCart>, IShoppingCartReadRepository
{
    public ShoppingCartReadRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ShoppingCart>> GetUsersShoppingCartsAsync(string userId)
    => await _query.Where(x=>x.ApplicationUserId == userId).ToListAsync();
    
}
