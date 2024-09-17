

using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Repositories;

public interface IOrderDetailsReadRepository: IReadRepository<OrderDetails>
{
    Task<IEnumerable<OrderDetails>> GetByOrderIdOrderDetailsAsync(string orderId);
}
