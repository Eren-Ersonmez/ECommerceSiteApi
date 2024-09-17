

using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.ProductImageFileDtos;

namespace ECommerceSiteApi.Application.Features.Queries.ProductImageFiles.GetProductImageFile;

public class GetProductImageFileQueryResponse
{
    public CustomResponseDto<ProductImageFileDto> CustomResponseDto { get; set; }
}
