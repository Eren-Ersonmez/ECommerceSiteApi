using AutoMapper;
using ECommerceSiteApi.Application.DTOs.ProductImageFileDtos;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Mapping
{
    public class ProductImageFileProfile:Profile
    {
        public ProductImageFileProfile()
        {
            CreateMap<ProductImageFile, ProductImageFileDto>().ReverseMap();
            CreateMap<ProductImageFile, ProductImageFileCreateDto>().ReverseMap();

        }
    }
}
