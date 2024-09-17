using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.ProductImageFiles.GetProductImageFile;

public class GetProductImageFileQueryRequest:IRequest<GetProductImageFileQueryResponse>
{
    public string Id { get; set; }
}
