

using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.ProductImageFileDtos;

namespace ECommerceSiteApi.Application.Features.Queries.ProductImageFiles.GetProductImagesFiles;

public class GetProductImagesFilesQueryResponse
{
    public CustomResponseDto<IEnumerable<ProductImageFileDto>> CustomResponseDto { get; set; }
}
