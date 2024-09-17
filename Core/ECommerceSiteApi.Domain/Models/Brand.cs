

using ECommerceSiteApi.Domain.Models.Common;

namespace ECommerceSiteApi.Domain.Models;

public class Brand:BaseEntity
{
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public IEnumerable<Product> Products { get; set; }  
}
