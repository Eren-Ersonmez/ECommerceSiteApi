
using AutoMapper;
using ECommerceSiteApi.Application.DTOs.BrandDtos;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Mapping;

public class BrandProfile:Profile
{
    public BrandProfile()
    {
        CreateMap<Brand, BrandDto>().ReverseMap();
        CreateMap<Brand, BrandCreateDto>().ReverseMap();
        CreateMap<Brand, BrandUpdateDto>().ReverseMap();
    }
}
