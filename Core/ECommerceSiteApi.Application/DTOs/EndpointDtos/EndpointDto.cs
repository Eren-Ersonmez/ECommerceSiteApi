

using ECommerceSiteApi.Application.DTOs.MenuDtos;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.DTOs.EndpointDtos;

public class EndpointDto: BaseDto
{
    public Guid Id { get; set; }
    public Guid MenuId { get; set; }
    public string ActionType { get; set; }
    public string HttpType { get; set; }
    public string Definition { get; set; }
    public string Code { get; set; }
    public ICollection<AppRole> Roles { get; set; }
}
