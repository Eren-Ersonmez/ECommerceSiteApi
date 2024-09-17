

namespace ECommerceSiteApi.Domain.Models
{
    public class ProductImageFile:BaseFile
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }    
    }
}
