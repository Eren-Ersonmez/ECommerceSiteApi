

namespace ECommerceSiteApi.Application.DTOs.OrderDetailsDtos;

public class OrderDetailsCreateDto:BaseDto
{
    public Guid ProductId { get; set; }
    public Guid OrderId { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
}
