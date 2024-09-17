using ECommerceSiteApi.Application.Repositories;
using ECommerceSiteApi.Domain.Models;
using ECommerceSiteApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSiteApi.Persistence.Repositories;

public class OrderDetailsReadRepository : ReadRepository<OrderDetails>, IOrderDetailsReadRepository
{
    public OrderDetailsReadRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<OrderDetails>> GetByOrderIdOrderDetailsAsync(string orderId)
    => await _query.Include(x=>x.Product).Where(x=>x.OrderId==Guid.Parse(orderId)).ToListAsync(); 
    
}
