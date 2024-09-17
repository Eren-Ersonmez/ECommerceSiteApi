

using ECommerceSiteApi.Application.DTOs.EndpointDtos;

namespace ECommerceSiteApi.Application.DTOs.MenuDtos;

public class MenuDto:BaseDto
{
    public Guid Id { get; set; }    
    public string Name { get; set; }
    public ICollection<EndpointDto> Endpoints { get; set; }
}
