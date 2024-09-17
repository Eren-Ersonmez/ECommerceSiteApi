using AutoMapper;
using ECommerceSiteApi.Application.DTOs.CreditCardDtos;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Mapping
{
    public class CreditCardProfile:Profile
    {
        public CreditCardProfile()
        {
            CreateMap<CreditCard, CreditCardDto>().ReverseMap();
            CreateMap<CreditCard, CreditCardCreateDto>().ReverseMap();
            CreateMap<CreditCard, CreditCardUpdateDto>().ReverseMap();

        }
    }
}
