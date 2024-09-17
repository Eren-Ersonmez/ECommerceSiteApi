
using ECommerceSiteApi.Domain.Models.Common;

namespace ECommerceSiteApi.Domain.Models
{
    public class Order:BaseEntity
    {
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public double OrderTotal { get; set; }
        public string OrderStatus { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }
        public Guid CreditCardId { get; set; }
        public virtual CreditCard CreditCard { get; set; }

    }
}
