

using ECommerceSiteApi.Application.DTOs.ProductDtos;

namespace ECommerceSiteApi.Application.DTOs.CategoryDtos
{
    public class CategoryDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }


    }
}
