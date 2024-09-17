

using ECommerceSiteApi.Domain.Models.Common;

namespace ECommerceSiteApi.Domain.Models;

public class UserCommentLike:BaseEntity
{
    public string UserId { get; set; }
    public Guid CommentId { get; set; }
}
