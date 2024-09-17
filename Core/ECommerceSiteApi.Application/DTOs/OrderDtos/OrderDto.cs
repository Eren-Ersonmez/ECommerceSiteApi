

using ECommerceSiteApi.Application.DTOs.AddressDtos;
using ECommerceSiteApi.Application.DTOs.ApplicationUserDtos;
using ECommerceSiteApi.Application.DTOs.CreditCardDtos;
using ECommerceSiteApi.Application.DTOs.OrderDetailsDtos;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.DTOs.OrderDtos
{
    public class OrderDto : BaseDto
    {
        public Guid Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUserDto ApplicationUser { get; set; }
        public double OrderTotal { get; set; }
        public string OrderStatus { get; set; }
        public Guid AddressId { get; set; }
        public AddressDto Address { get; set; }
        public Guid CreditCardId { get; set; }
        public IEnumerable<Guid> OrderDetailIds { get; set; }
        public IEnumerable<OrderDetailsDto> OrderDetails { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
