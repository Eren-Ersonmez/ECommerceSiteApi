

namespace ECommerceSiteApi.Application.UnitOfWorks
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }
}
