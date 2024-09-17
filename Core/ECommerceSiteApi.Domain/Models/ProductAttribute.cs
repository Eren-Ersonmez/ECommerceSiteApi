

using ECommerceSiteApi.Domain.Models.Common;

namespace ECommerceSiteApi.Domain.Models;

public class ProductAttribute:BaseEntity
{
    public Guid ProductId { get; set; }  
    public virtual Product Product { get; set; }
    public string AttributeName { get; set; } 
    public string AttributeValue { get; set; } 
}
