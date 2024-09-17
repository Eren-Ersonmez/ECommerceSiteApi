using ECommerceSiteApi.Application.DTOs.ProductImageFileDtos;
using ECommerceSiteApi.Application.Services;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using MediatR;


namespace ECommerceSiteApi.Application.Features.Queries.ProductImageFiles.GetProductImageFile;

public class GetProductImageFileQueryHandler : IRequestHandler<GetProductImageFileQueryRequest, GetProductImageFileQueryResponse>
{
    private readonly IFileService<ProductImageFile, ProductImageFileDto> _fileService;

    public GetProductImageFileQueryHandler(IFileService<ProductImageFile, ProductImageFileDto> fileService)
    => _fileService = fileService;
    

    public async Task<GetProductImageFileQueryResponse> Handle(GetProductImageFileQueryRequest request, CancellationToken cancellationToken)
    => new() { CustomResponseDto = await _fileService.GetByIdAsync(request.Id) };
    
}
