using AutoMapper;
using ECommerceSiteApi.Application.DTOs.MenuDtos;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Mapping;

public class MenuProfile:Profile
{
    public MenuProfile()
    {
        CreateMap<Menu, MenuDto>().ReverseMap();
        CreateMap<Menu, MenuCreateDto>().ReverseMap();
        CreateMap<Menu, MenuUpdateDto>().ReverseMap();
    }
}
