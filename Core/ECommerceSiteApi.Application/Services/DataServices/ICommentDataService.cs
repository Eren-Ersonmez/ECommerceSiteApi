

using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.CommentDtos;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Services.DataServices;

public interface ICommentDataService:IDataService<Comment,CommentDto>
{
    Task<CustomResponseDto<CommentDto>> AddCommentAsync(CommentCreateDto commentDto);   
    Task<CustomResponseDto<IEnumerable<CommentDto>>> GetAllProductCommentsAsync(string productId);
    Task<CustomResponseDto<NoContentDto>> LikedCommentAsync(string id);
}
