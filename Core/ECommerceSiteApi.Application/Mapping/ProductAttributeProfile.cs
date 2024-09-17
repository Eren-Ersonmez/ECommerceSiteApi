

using AutoMapper;
using ECommerceSiteApi.Application.DTOs.ProductAttributeDtos;
using ECommerceSiteApi.Application.DTOs.ProductDtos;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Mapping;

public class ProductAttributeProfile:Profile
{
    public ProductAttributeProfile()
    {
        CreateMap<ProductAttribute, ProductAttributeDto>().ReverseMap();
        CreateMap<ProductAttribute, ProductAttributeCreateDto>().ReverseMap();
    }
}
