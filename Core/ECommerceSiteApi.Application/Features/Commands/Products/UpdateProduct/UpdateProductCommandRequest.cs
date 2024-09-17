

using ECommerceSiteApi.Application.DTOs.ProductDtos;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.Products.UpdateProduct;

public class UpdateProductCommandRequest:IRequest<UpdateProductCommandResponse>
{
    public ProductUpdateDto ProductUpdateDto { get; set; }  
}
