using AutoMapper;
using ECommerceSiteApi.Application.DTOs.EndpointDtos;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Mapping;

public class EndpointProfile:Profile
{
    public EndpointProfile()
    {
        CreateMap<Endpoint, EndpointDto>().ReverseMap();
        CreateMap<Endpoint, EndpointCreateDto>().ReverseMap();
        CreateMap<Endpoint, EndpointUpdateDto>().ReverseMap();
    }
}
