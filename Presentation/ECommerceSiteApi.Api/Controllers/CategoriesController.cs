using ECommerceSiteApi.Application.Features.Commands.Categories.AddCategory;
using ECommerceSiteApi.Application.Features.Commands.Categories.DeleteCategory;
using ECommerceSiteApi.Application.Features.Commands.Categories.UpdateCategory;
using ECommerceSiteApi.Application.Features.Queries.Categories.GetCategories;
using ECommerceSiteApi.Application.Features.Queries.Categories.GetCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSiteApi.Api.Controllers;

public class CategoriesController : CustomBaseController
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    => _mediator = mediator;
    

    [HttpGet]
    public async Task<IActionResult> GetCategories([FromQuery] GetCategoriesQueryRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory([FromRoute] GetCategoryQueryRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);
    
    [HttpPost]
    public async Task<IActionResult> AddCategory(AddCategoryCommandRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] DeleteCategoryCommandRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);
    
}
