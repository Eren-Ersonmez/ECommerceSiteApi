using ECommerceSiteApi.Application.Constants;
using ECommerceSiteApi.Application.CustomAttributes;
using ECommerceSiteApi.Application.Enums;
using ECommerceSiteApi.Application.Features.Commands.Products.AddProduct;
using ECommerceSiteApi.Application.Features.Commands.Products.DeleteProduct;
using ECommerceSiteApi.Application.Features.Commands.Products.UpdateProduct;
using ECommerceSiteApi.Application.Features.Commands.Products.UpdateStockQrCodeToProduct;
using ECommerceSiteApi.Application.Features.Queries.Products.GetCategoryProducts;
using ECommerceSiteApi.Application.Features.Queries.Products.GetProduct;
using ECommerceSiteApi.Application.Features.Queries.Products.GetProductQrCode;
using ECommerceSiteApi.Application.Features.Queries.Products.GetProducts;
using ECommerceSiteApi.Application.Features.Queries.Products.GetProductsWithCategory;
using ECommerceSiteApi.Application.Services.DataServices;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSiteApi.Api.Controllers;

public class ProductsController : CustomBaseController
{
    private readonly IMediator _mediator;
    private readonly IProductDataService _productDataService;

    public ProductsController(IMediator mediator,IProductDataService productDataService)
    { 
        _mediator = mediator;
        _productDataService = productDataService;
    }
    

    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] GetProductsQueryRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct([FromRoute]GetProductQueryRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

    [HttpGet("qrcode/{productId}")]
    public async Task<IActionResult> GetProductQrCode([FromRoute] GetProductQrCodeQueryRequest request)
    { 
       var values= (await _mediator.Send(request)).CustomResponseDto;
       return File(values.Data, "image/png");
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetProductsWithCategory([FromQuery] GetProductsWithCategoryQueryRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

    [HttpGet("[action]")]
    public async Task<IActionResult> GetBrandProducts(string brandId)
    => CreateActionResult(await _productDataService.WhereAsync(x=>x.BrandId==Guid.Parse(brandId)));

    [HttpGet("[action]")]
    public async Task<IActionResult> GetCategoryProducts([FromQuery] GetCategoryProductsQueryRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);


    [Authorize(AuthenticationSchemes = "Admin")]
    [HttpPost]
    [AuthorizeDefination(Menu = AuthorizeDefinationCustom.Products, ActionType = ActionType.Writing, Defination = "Add Product")]
    public async Task<IActionResult> AddProduct(AddProductCommandRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);
    

    [Authorize(AuthenticationSchemes = "Admin")]
    [HttpDelete("{id}")]
    [AuthorizeDefination(Menu = AuthorizeDefinationCustom.Products, ActionType = ActionType.Deleting, Defination = "Delete Product")]
    public async Task<IActionResult> DeleteProduct([FromRoute]DeleteProductCommandRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

    [Authorize(AuthenticationSchemes = "Admin")]
    [HttpPut]
    [AuthorizeDefination(Menu = AuthorizeDefinationCustom.Products, ActionType = ActionType.Updating, Defination = "Update Product")]
    public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

    [Authorize(AuthenticationSchemes = "Admin")]
    [HttpPut("[action]")]
    [AuthorizeDefination(Menu = AuthorizeDefinationCustom.Products, ActionType = ActionType.Updating, Defination = "Update Product")]
    public async Task<IActionResult> UpdateStockQrCodeToProduct(UpdateStockQrCodeToProductCommandRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);


}

