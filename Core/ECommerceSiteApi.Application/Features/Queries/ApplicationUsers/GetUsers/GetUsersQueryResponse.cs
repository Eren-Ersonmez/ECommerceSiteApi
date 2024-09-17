using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.ApplicationUserDtos;

namespace ECommerceSiteApi.Application.Features.Queries.ApplicationUsers.GetUsers;

public class GetUsersQueryResponse
{
    public CustomResponseDto<IEnumerable<ApplicationUserDto>> CustomResponseDto { get; set; }
}