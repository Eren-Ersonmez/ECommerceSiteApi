

using ECommerceSiteApi.Application.DTOs.ProductDtos;

namespace ECommerceSiteApi.Application.DTOs.ShoppingCartDtos
{
    public class ShoppingCartUpdateDto : BaseDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }

    }
}
