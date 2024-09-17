

namespace ECommerceSiteApi.Application.DTOs.CommentDtos
{
    public class CommentUpdateDto:BaseDto
    {
        public Guid Id { get; set; }
        public string CommentContent { get; set; }

    }
}
