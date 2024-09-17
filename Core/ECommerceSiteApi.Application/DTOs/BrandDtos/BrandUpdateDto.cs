

namespace ECommerceSiteApi.Application.DTOs.BrandDtos;

public class BrandUpdateDto:BaseDto
{
    public string BrandId { get; set; }
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
}
