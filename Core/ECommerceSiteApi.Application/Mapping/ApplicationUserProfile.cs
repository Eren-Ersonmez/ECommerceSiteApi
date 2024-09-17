using AutoMapper;
using ECommerceSiteApi.Application.DTOs.ApplicationUserDtos;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Mapping
{
    public class ApplicationUserProfile:Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserCreateDto>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserUpdateDto>().ReverseMap();

        }
    }
}
