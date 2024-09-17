using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Features.Queries.Roles.GetRoles;

public class GetRolesQueryResponse
{
    public CustomResponseDto<IEnumerable<AppRole>> CustomResponseDto { get; set; }
}