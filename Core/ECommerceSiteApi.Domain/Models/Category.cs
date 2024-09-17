

using ECommerceSiteApi.Domain.Models.Common;

namespace ECommerceSiteApi.Domain.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Brand> Brands { get; set; }
    }
}
