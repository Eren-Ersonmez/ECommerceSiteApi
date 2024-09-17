
using ECommerceSiteApi.Application.DTOs.BaseFileDtos;

namespace ECommerceSiteApi.Application.DTOs.ProductImageFileDtos
{
    public class ProductImageFileCreateDto:BaseFileCreateDto
    {
        public Guid ProductId { get; set; }

    }
}
