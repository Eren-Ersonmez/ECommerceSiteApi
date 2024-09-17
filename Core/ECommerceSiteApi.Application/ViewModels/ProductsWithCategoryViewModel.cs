

using ECommerceSiteApi.Application.DTOs.CategoryDtos;
using ECommerceSiteApi.Application.DTOs.ProductDtos;

namespace ECommerceSiteApi.Application.ViewModels
{
    public class ProductsWithCategoryViewModel:ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
