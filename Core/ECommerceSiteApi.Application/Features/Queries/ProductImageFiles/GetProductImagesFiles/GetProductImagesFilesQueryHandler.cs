using ECommerceSiteApi.Application.DTOs.ProductImageFileDtos;
using ECommerceSiteApi.Application.Services;
using ECommerceSiteApi.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSiteApi.Application.Features.Queries.ProductImageFiles.GetProductImagesFiles;

public class GetProductImagesFilesQueryHandler : IRequestHandler<GetProductImagesFilesQueryRequest, GetProductImagesFilesQueryResponse>
{
    private readonly IFileService<ProductImageFile,ProductImageFileDto> _fileService;

    public GetProductImagesFilesQueryHandler(IFileService<ProductImageFile, ProductImageFileDto> fileService)
    => _fileService = fileService;
    

    async Task<GetProductImagesFilesQueryResponse> IRequestHandler<GetProductImagesFilesQueryRequest, GetProductImagesFilesQueryResponse>.Handle(GetProductImagesFilesQueryRequest request, CancellationToken cancellationToken)

    => new() { CustomResponseDto = await _fileService.WhereAsync(x => x.ProductId == Guid.Parse(request.ProductId)) }; 

    
}
