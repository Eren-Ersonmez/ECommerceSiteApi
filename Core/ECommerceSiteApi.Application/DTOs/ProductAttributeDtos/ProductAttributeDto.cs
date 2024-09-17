
using ECommerceSiteApi.Application.DTOs.ProductDtos;
namespace ECommerceSiteApi.Application.DTOs.ProductAttributeDtos;

public class ProductAttributeDto:BaseDto
{
    public Guid ProductId { get; set; }
    public virtual ProductDto Product { get; set; }
    public string AttributeName { get; set; }
    public string AttributeValue { get; set; }
}
