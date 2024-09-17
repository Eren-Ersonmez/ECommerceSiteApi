

using ECommerceSiteApi.Application.DTOs.ApplicationUserDtos;

namespace ECommerceSiteApi.Application.DTOs.CommentDtos
{
    public class CommentDto:BaseDto
    {
        public Guid Id { get; set; }
        public string CommentContent { get; set; }
        public Guid ProductId { get; set; }
        public ApplicationUserDto ApplicationUser { get; set; }
        public int LikeCount { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
