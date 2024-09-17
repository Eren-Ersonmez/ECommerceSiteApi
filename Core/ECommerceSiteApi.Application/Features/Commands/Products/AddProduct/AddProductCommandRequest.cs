

using ECommerceSiteApi.Application.DTOs.ProductDtos;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.Products.AddProduct
{
    public class AddProductCommandRequest:IRequest<AddProductCommandResponse>
    {
        public ProductCreateDto Dto { get; set; }
    }
}
