using AutoMapper;
using ECommerceSiteApi.Application.DTOs.ShoppingCartDtos;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Mapping
{
    public class ShoppingCartProfile:Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartDto>().ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartCreateDto>().ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartUpdateDto>().ReverseMap();

        }
    }
}
