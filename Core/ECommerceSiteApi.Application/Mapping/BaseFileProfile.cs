using AutoMapper;
using ECommerceSiteApi.Application.DTOs.BaseFileDtos;
using ECommerceSiteApi.Application.DTOs.ShoppingCartDtos;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Mapping
{
    public class BaseFileProfile:Profile
    {
        public BaseFileProfile()
        {
            CreateMap<BaseFile, BaseFileDto>().ReverseMap();
            CreateMap<BaseFile, BaseFileCreateDto>().ReverseMap();
        }
    }
}
