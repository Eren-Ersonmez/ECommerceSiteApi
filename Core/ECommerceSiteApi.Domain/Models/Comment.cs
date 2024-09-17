

using ECommerceSiteApi.Domain.Models.Common;

namespace ECommerceSiteApi.Domain.Models
{
    public class Comment:BaseEntity
    {
        public string CommentContent { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int LikeCount {  get; set; }
    }
}
