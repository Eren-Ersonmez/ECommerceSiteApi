using ECommerceSiteApi.Application.DTOs;

namespace ECommerceSiteApi.Application.Features.Queries.Products.GetProductQrCode;

public class GetProductQrCodeQueryResponse
{
    public CustomResponseDto<Byte[]> CustomResponseDto { get; set; }
}