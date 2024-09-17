using AutoMapper;
using ECommerceSiteApi.Application.DTOs.CommentDtos;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Mapping
{
    public class CommentProfile:Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Comment, CommentCreateDto>().ReverseMap();
            CreateMap<CommentDto, CommentUpdateDto>().ReverseMap();

        }
    }
}
