

using ECommerceSiteApi.Application.DTOs.AddressDtos;
using ECommerceSiteApi.Application.DTOs.CreditCardDtos;
using ECommerceSiteApi.Application.DTOs.OrderDetailsDtos;

namespace ECommerceSiteApi.Application.DTOs.OrderDtos
{
    public class OrderCreateDto : BaseDto
    {
        public string ApplicationUserId { get; set; }
        public double OrderTotal { get; set; }
        public string OrderStatus { get; set; }
        public Guid AddressId { get; set; }
        public Guid CreditCardId { get; set; }
        public IEnumerable<Guid> OrderDetailIds { get; set; }

    }
}
