

using ECommerceSiteApi.Domain.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSiteApi.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
         DbSet<T> DataTable { get; }
    }
}
