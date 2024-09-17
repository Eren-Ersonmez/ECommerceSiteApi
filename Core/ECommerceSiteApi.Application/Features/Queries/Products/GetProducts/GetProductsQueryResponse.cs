using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.ProductDtos;

namespace ECommerceSiteApi.Application.Features.Queries.Products.GetProducts
{
    public class GetProductsQueryResponse
    {
       public CustomResponseDto<IEnumerable<ProductDto>> CustomResponseDto { get; set; }
    }
}
