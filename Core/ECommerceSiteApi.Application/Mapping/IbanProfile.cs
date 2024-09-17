using AutoMapper;
using ECommerceSiteApi.Application.DTOs.IbanDtos;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Mapping
{
    public class IbanProfile:Profile
    {
        public IbanProfile()
        {
            CreateMap<Iban, IbanDto>().ReverseMap();
            CreateMap<Iban, IbanCreateDto>().ReverseMap();
            CreateMap<Iban, IbanUpdateDto>().ReverseMap();

        }
    }
}
