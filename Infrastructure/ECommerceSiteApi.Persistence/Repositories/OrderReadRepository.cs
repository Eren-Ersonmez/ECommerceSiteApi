

using ECommerceSiteApi.Application.Repositories;
using ECommerceSiteApi.Domain.Models;
using ECommerceSiteApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSiteApi.Persistence.Repositories;

public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
{

    public OrderReadRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Order> GetOrderWithModels(string id,bool tracking = true)
    {
        if (tracking)
        {
             Order order= await _query.Include(x => x.Address).Include(x=>x.OrderDetails).Include(x=>x.ApplicationUser).FirstOrDefaultAsync(x=>x.Id==Guid.Parse(id));
            return order;
        }
        return await _query.AsNoTracking().Include(x => x.Address).Include(x => x.OrderDetails).Include(x => x.ApplicationUser).FirstOrDefaultAsync(x=>x.Id == Guid.Parse(id));
    }
}
