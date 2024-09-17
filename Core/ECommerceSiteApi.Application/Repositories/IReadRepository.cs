using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Domain.Models.Common;
using System.Linq.Expressions;


namespace ECommerceSiteApi.Application.Repositories
{
    public interface IReadRepository<T>:IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(Pagination pagination,bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);
        IQueryable<T> Where(Expression<Func<T,bool>> expression,bool tracking=true);
        Task<T> GetSingleValueAsync(Expression<Func<T, bool>> expression, bool tracking = true);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression, bool tracking = true);

    }
}
