

namespace ECommerceSiteApi.Application.DTOs.CommentDtos
{
    public class CommentCreateDto:BaseDto
    {
        public string CommentContent { get; set; }
        public  Guid ProductId { get; set; }
        public string? ApplicationUserId { get; set; }

    }
}
