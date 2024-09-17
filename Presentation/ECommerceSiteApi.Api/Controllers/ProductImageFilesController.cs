using ECommerceSiteApi.Application.Constants;
using ECommerceSiteApi.Application.CustomAttributes;
using ECommerceSiteApi.Application.Enums;
using ECommerceSiteApi.Application.Features.Commands.ProductImageFiles.AddProductImagesFile;
using ECommerceSiteApi.Application.Features.Commands.ProductImageFiles.DeleteProductImagesFile;
using ECommerceSiteApi.Application.Features.Queries.ProductImageFiles.GetProductImageFile;
using ECommerceSiteApi.Application.Features.Queries.ProductImageFiles.GetProductImagesFiles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSiteApi.Api.Controllers;

public class ProductImageFilesController : CustomBaseController
{
    private readonly IMediator _mediator;
    public ProductImageFilesController(IMediator mediator)
    => _mediator = mediator;
    [HttpGet]
    public async Task<IActionResult> GetProductImagesFiles([FromQuery]GetProductImagesFilesQueryRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductImageFile([FromRoute] GetProductImageFileQueryRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

    [HttpPost]
    [Authorize(AuthenticationSchemes = "Admin")]
    [AuthorizeDefination(Menu = AuthorizeDefinationCustom.ProductImageFiles, ActionType = ActionType.Writing, Defination = "Add Product Images File")]
    public async Task<IActionResult> AddProductImagesFile(AddProductImagesFileCommandRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

    [HttpDelete("{id}")]
    [Authorize(AuthenticationSchemes = "Admin")]
    [AuthorizeDefination(Menu = AuthorizeDefinationCustom.ProductImageFiles, ActionType = ActionType.Deleting, Defination = "Delete Product Images File")]
    public async Task<IActionResult> DeleteProductImagesFile([FromRoute] DeleteProductImagesFileCommandRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);


}
