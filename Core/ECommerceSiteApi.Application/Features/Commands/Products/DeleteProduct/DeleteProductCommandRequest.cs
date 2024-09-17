

using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.Products.DeleteProduct
{
    public class DeleteProductCommandRequest:IRequest<DeleteProductCommandResponse>
    {
        public string Id { get; set; }
    }
}
