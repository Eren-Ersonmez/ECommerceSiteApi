

using ECommerceSiteApi.Application.DTOs.ProductImageFileDtos;
using ECommerceSiteApi.Application.Services;
using ECommerceSiteApi.Domain.Models;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ProductImageFiles.DeleteProductImagesFile;

public class DeleteProductImagesFileCommandHandler : IRequestHandler<DeleteProductImagesFileCommandRequest, DeleteProductImagesFileCommandResponse>
{
    private readonly IFileService<ProductImageFile,ProductImageFileDto> _fileService;

    public DeleteProductImagesFileCommandHandler(IFileService<ProductImageFile, ProductImageFileDto> fileService)
    => _fileService = fileService;
    

    public async Task<DeleteProductImagesFileCommandResponse> Handle(DeleteProductImagesFileCommandRequest request, CancellationToken cancellationToken)
    => new() {CustomResponseDto= await _fileService.RemoveAsync(request.Id) };
       
    
}
