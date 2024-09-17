using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Repositories;

public interface IProductReadRepository:IReadRepository<Product>
{
    Task<IEnumerable<Product>> GetAllWithCategoryAsync(Pagination pagination, bool tracking = true);
    Task<Product> GetProductWithImagesAsync(string id,bool tracking=true);

}
