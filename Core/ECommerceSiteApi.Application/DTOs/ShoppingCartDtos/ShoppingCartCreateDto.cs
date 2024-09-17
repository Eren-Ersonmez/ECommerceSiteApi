
namespace ECommerceSiteApi.Application.DTOs.ShoppingCartDtos
{
    public class ShoppingCartCreateDto:BaseDto
    {
        public string? ApplicationUserId { get; set; }
        public Guid ProductId { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }

    }
}
