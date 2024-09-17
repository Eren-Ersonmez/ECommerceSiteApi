

using AutoMapper;
using ECommerceSiteApi.Application.DTOs.OrderDetailsDtos;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Mapping;

public class OrderDetailsProfile:Profile
{
    public OrderDetailsProfile()
    {
        CreateMap<OrderDetails, OrderDetailsDto>().ReverseMap();
        CreateMap<OrderDetails, OrderDetailsCreateDto>().ReverseMap();
        CreateMap<OrderDetails, OrderDetailsUpdateDto>().ReverseMap();
    }
}
