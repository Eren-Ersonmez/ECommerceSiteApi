

using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Repositories.CommentRepositories;

public interface ICommentWriteRepository:IWriteRepository<Comment>
{
   Task<Comment> AddCommentAsync(Comment comment);
}
