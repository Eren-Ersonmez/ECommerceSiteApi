using ECommerceSiteApi.Application.Repositories;
using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Domain.Models.Common;
using ECommerceSiteApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerceSiteApi.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        protected readonly IQueryable<T> _query;

        public ReadRepository(ApplicationDbContext context)
        {
            _context = context;
            DataTable = _context.Set<T>();
            _query = DataTable.AsQueryable();
        }

        public DbSet<T> DataTable { get; }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression, bool tracking = false)
        {
            if (tracking)
            {
               return await _query.AsNoTracking().AnyAsync(expression);
            }
            return await DataTable.AnyAsync(expression);
        }

        public IQueryable<T> GetAll(Pagination pagination, bool tracking = true)
        {
            if (!tracking)
            {
                return _query.AsNoTracking().Skip(pagination.Page*pagination.PageSize).Take(pagination.PageSize);
            }
            return _query;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            if (!tracking)
            {
                return await _query.AsNoTracking().FirstOrDefaultAsync(x => x.Id==Guid.Parse(id));
            }
            return await _query.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleValueAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            if (!tracking)
            {
                return await _query.AsNoTracking().FirstOrDefaultAsync(expression);
            }
            return await _query.FirstOrDefaultAsync(expression);

        }

        public  IQueryable<T> Where(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            if (!tracking)
            {
                return  _query.AsNoTracking().Where(expression);
            }
            return _query.Where(expression);
        }
    }
}
