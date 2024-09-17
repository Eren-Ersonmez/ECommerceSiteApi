using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Repositories.CommentRepositories;

public interface ICommentReadRepository : IReadRepository<Comment>
{
    Task<IEnumerable<Comment>> GetProductComments(string productId);
}
