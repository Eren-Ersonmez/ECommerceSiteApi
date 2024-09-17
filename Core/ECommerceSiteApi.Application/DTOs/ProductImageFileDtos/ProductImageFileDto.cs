

using ECommerceSiteApi.Application.DTOs.BaseFileDtos;

namespace ECommerceSiteApi.Application.DTOs.ProductImageFileDtos
{
    public class ProductImageFileDto:BaseFileDto
    {
        public Guid ProductId { get; set; }
    }

}
