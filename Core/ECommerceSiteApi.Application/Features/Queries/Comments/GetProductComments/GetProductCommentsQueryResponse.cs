using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.CommentDtos;

namespace ECommerceSiteApi.Application.Features.Queries.Comments.GetProductComment;

public class GetProductCommentsQueryResponse
{
    public CustomResponseDto<IEnumerable<CommentDto>> CustomResponseDto { get; set; }
}