using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.ProductDtos;

namespace ECommerceSiteApi.Application.Features.Queries.Products.GetCategoryProducts;

public class GetCategoryProductsQueryResponse
{
    public CustomResponseDto<IEnumerable<ProductDto>> CustomResponseDto { get; set; }
}