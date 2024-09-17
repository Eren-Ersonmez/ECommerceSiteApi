using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Products.GetProductQrCode;

public class GetProductQrCodeQueryRequest:IRequest<GetProductQrCodeQueryResponse>
{
    public string ProductId { get; set; }
}