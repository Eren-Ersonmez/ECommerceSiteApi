

namespace ECommerceSiteApi.Application.DTOs.BrandDtos;

public class BrandCreateDto:BaseDto
{
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
}
