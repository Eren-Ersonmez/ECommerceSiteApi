

using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.ProductImageFiles.GetProductImagesFiles;

public class GetProductImagesFilesQueryRequest:IRequest<GetProductImagesFilesQueryResponse>
{
    public string ProductId { get; set; }
}
