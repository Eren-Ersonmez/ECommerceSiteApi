

using ECommerceSiteApi.Application.DTOs.CommentDtos;
using ECommerceSiteApi.Application.DTOs.ProductImageFileDtos;

namespace ECommerceSiteApi.Application.DTOs.ProductDtos
{
    public class ProductDto:BaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public bool IsHome { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
        public double RatingPoint { get; set; }
        public Guid CategoryId { get; set; }
        public IEnumerable<ProductImageFileDto> ImageFiles { get; set; }

    }
}
