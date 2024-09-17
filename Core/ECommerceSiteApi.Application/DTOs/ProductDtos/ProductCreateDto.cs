

namespace ECommerceSiteApi.Application.DTOs.ProductDtos
{
    public class ProductCreateDto:BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public bool IsHome { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }

    }
}
