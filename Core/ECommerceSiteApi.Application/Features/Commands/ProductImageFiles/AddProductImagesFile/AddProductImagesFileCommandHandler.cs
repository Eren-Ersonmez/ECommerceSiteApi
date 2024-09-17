

using ECommerceSiteApi.Application.DTOs.ProductImageFileDtos;
using ECommerceSiteApi.Application.Services;
using ECommerceSiteApi.Domain.Models;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ProductImageFiles.AddProductImagesFile;

public class AddProductImagesFileCommandHandler : IRequestHandler<AddProductImagesFileCommandRequest, AddProductImagesFileCommandResponse>
{
    private readonly IFileService<ProductImageFile,ProductImageFileDto> _fileService;

    public AddProductImagesFileCommandHandler(IFileService<ProductImageFile, ProductImageFileDto> fileService)
    => _fileService = fileService;
    

    public async Task<AddProductImagesFileCommandResponse> Handle(AddProductImagesFileCommandRequest request, CancellationToken cancellationToken)
    => new() { CustomResponseDto= await _fileService.UploadAsync<ProductImageFileCreateDto>(request.Files, new Dictionary<string, object> { { "ProductId", request.ProductId } }) };

    
}
