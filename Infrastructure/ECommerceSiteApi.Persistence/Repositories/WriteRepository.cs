using ECommerceSiteApi.Application.Repositories;
using ECommerceSiteApi.Domain.Models.Common;
using ECommerceSiteApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace ECommerceSiteApi.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<WriteRepository<T>> _logger;
        public DbSet<T> DataTable { get; }

        public WriteRepository(ApplicationDbContext context,ILogger<WriteRepository<T>> logger)
        {
            _context = context;
            DataTable = _context.Set<T>();
            _logger = logger;
        }

       
        public async Task<T> AddAsync(T entity)
        {
           EntityEntry<T> entry = await DataTable.AddAsync(entity);
           return entry.Entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        =>await DataTable.AddRangeAsync(entities);

        public bool Delete(T entity)
        {
            EntityEntry<T> entityEntry=DataTable.Remove(entity);
            return entityEntry.Entity != null;
        }   

        public bool DeleteRange(IEnumerable<T> entities)
        {
            try
            {
                DataTable.RemoveRange(entities);
            }
            catch (Exception ex) 
            { 
              return false;
            }
            return true;
        }

        public bool Update(T entity)
        {
            EntityEntry entry=DataTable.Update(entity); 
            return entry.Entity != null;
        }
    }
}
