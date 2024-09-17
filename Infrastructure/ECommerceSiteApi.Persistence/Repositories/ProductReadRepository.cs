using ECommerceSiteApi.Application.Repositories;
using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Domain.Models;
using ECommerceSiteApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSiteApi.Persistence.Repositories;

public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
{
    public ProductReadRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetAllWithCategoryAsync(Pagination pagination, bool tracking = true)
    {
        var values=_query.Skip(pagination.PageSize*pagination.Page).Take(pagination.PageSize);
        if (tracking) 
        {
            return await values.Include(x => x.Category).ToListAsync();
        }
        return await values.AsNoTracking().Include(x=>x.Category).ToListAsync();
    }

    public async Task<Product> GetProductWithImagesAsync(string id,bool tracking = true)
    {

        if (tracking)
        {
            return await _query.Include(x => x.ImageFiles).FirstOrDefaultAsync(x=>x.Id==Guid.Parse(id));
        }
        return await _query.AsNoTracking().Include(x => x.ImageFiles).FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
    }
}
