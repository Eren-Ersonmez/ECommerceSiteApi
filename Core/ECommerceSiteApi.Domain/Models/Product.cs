
using ECommerceSiteApi.Domain.Models.Common;

namespace ECommerceSiteApi.Domain.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int stock {  get; set; }
        public decimal Price { get; set; }
        public bool IsHome { get; set; }
        public double RatingPoint { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }  
        public Guid? BrandId { get; set; }
        public virtual Brand? Brand { get; set; }
        public ICollection<ProductImageFile> ImageFiles { get; set; }
        public ICollection<ProductAttribute> ProductAttributes { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

    }
}
