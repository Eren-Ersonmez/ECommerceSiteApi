

using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.DTOs.ProductAttributeDtos;

public class ProductAttributeCreateDto:BaseDto
{
    public Guid ProductId { get; set; }
    public string AttributeName { get; set; }
    public string AttributeValue { get; set; }
}
