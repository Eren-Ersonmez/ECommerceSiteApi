

using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.ProductDtos;

namespace ECommerceSiteApi.Application.Features.Commands.Products.AddProduct
{
    public class AddProductCommandResponse
    {
        public CustomResponseDto<ProductDto> CustomResponseDto { get; set; }   
    }
}
