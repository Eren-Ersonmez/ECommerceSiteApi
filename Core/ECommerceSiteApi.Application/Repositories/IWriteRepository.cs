using ECommerceSiteApi.Domain.Models.Common;

namespace ECommerceSiteApi.Application.Repositories
{
    public interface IWriteRepository<T>:IRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);  
        bool Update(T entity);
        bool Delete(T entity);
        bool DeleteRange(IEnumerable<T> entities);

    }
}
