
using ECommerceSiteApi.Application.DTOs.ProductDtos;

namespace ECommerceSiteApi.Application.DTOs.OrderDetailsDtos;

public class OrderDetailsDto:BaseDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public ProductDto Product { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
}
