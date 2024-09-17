

using MediatR;
using Microsoft.AspNetCore.Http;

namespace ECommerceSiteApi.Application.Features.Commands.ProductImageFiles.AddProductImagesFile;

public class AddProductImagesFileCommandRequest:IRequest<AddProductImagesFileCommandResponse>
{
   public IFormFileCollection Files {  get; set; }

   public string ProductId { get; set; }
}
