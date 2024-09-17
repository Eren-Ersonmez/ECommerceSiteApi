

using ECommerceSiteApi.Application.DTOs.CategoryDtos;
using ECommerceSiteApi.Application.DTOs.ProductDtos;

namespace ECommerceSiteApi.Application.DTOs.BrandDtos;

public class BrandDto:BaseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<ProductDto> Products { get; set; }
    public virtual CategoryDto Category { get; set; }

}
