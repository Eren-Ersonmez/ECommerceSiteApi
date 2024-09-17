
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ProductImageFiles.DeleteProductImagesFile;

public class DeleteProductImagesFileCommandRequest:IRequest<DeleteProductImagesFileCommandResponse>
{
    public string Id { get; set; }
}
