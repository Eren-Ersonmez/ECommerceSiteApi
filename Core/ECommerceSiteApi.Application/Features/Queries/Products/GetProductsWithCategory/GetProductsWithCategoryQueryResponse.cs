

using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.ViewModels;

namespace ECommerceSiteApi.Application.Features.Queries.Products.GetProductsWithCategory
{
    public class GetProductsWithCategoryQueryResponse
    {
        public CustomResponseDto<IEnumerable<ProductsWithCategoryViewModel>> CustomResponseDto { get; set; }
    }
}
