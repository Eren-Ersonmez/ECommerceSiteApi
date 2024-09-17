
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Repositories;

public interface IOrderReadRepository: IReadRepository<Order>
{
    Task<Order> GetOrderWithModels(string id,bool tracking = true);
}
