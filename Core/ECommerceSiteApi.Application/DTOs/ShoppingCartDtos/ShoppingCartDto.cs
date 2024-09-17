

using ECommerceSiteApi.Application.DTOs.ProductDtos;

namespace ECommerceSiteApi.Application.DTOs.ShoppingCartDtos
{
    public class ShoppingCartDto:BaseDto
    {
        public Guid Id { get; set; }
        public string? ApplicationUserId { get; set; }
        public Guid ProductId { get; set; }
        public ProductDto Product { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }

    }
}
