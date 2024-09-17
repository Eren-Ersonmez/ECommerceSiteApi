

using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.ProductDtos;

namespace ECommerceSiteApi.Application.Features.Queries.Products.GetProduct
{
    public class GetProductQueryResponse
    {
        public CustomResponseDto<ProductDto> CustomResponseDto { get; set; }   
    }
}
