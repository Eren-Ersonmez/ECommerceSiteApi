using AutoMapper;
using ECommerceSiteApi.Application.Constants;
using ECommerceSiteApi.Application.CustomAttributes;
using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.ApplicationUserDtos;
using ECommerceSiteApi.Application.DTOs.ProductDtos;
using ECommerceSiteApi.Application.Enums;
using ECommerceSiteApi.Application.Features.Commands.ApplicationUser.AddApplicationUser;
using ECommerceSiteApi.Application.Features.Commands.ApplicationUser.AssignRoles;
using ECommerceSiteApi.Application.Features.Queries.ApplicationUsers.GetUsers;
using ECommerceSiteApi.Application.Features.Queries.ApplicationUsers.GetUsersRoles;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Application.ViewModels;
using ECommerceSiteApi.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSiteApi.Api.Controllers;


public class ApplicationUsersController : CustomBaseController
{
    private readonly IMediator _mediator;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IProductDataService _productDataService;
    private readonly IMapper _mapper;
    private IUserService _userService;

    public ApplicationUsersController(IMediator mediator, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor, IProductDataService productDataService, IMapper mapper,IUserService userService)
    {
        _mediator = mediator;
        _userManager = userManager;
        _contextAccessor = contextAccessor;
        _productDataService = productDataService;
        _mapper = mapper;
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> AddApplicationUser(AddApplicationUserCommandRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

    [HttpGet]
    [Authorize(AuthenticationSchemes = "Admin")]
    [AuthorizeDefination(Menu = AuthorizeDefinationCustom.ApplicationUsers, ActionType = ActionType.Reading, Defination = "Get Users")]
    public async Task<IActionResult> GetUsers([FromQuery] GetUsersQueryRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

    [HttpGet("{userId}")]
    [Authorize(AuthenticationSchemes = "Admin")]
    [AuthorizeDefination(Menu = AuthorizeDefinationCustom.ApplicationUsers, ActionType = ActionType.Reading, Defination = "Get User's Roles")]
    public async Task<IActionResult> GetUsersRoles([FromRoute]GetUsersRolesQueryRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

    [HttpPost("[action]")]
    [Authorize(AuthenticationSchemes = "Admin")]
    [AuthorizeDefination(Menu = AuthorizeDefinationCustom.ApplicationUsers, ActionType = ActionType.Reading, Defination = "Assign Roles")]
    public async Task<IActionResult> AssignRoles([FromBody]AssignRolesCommandRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

    [HttpPost("[action]")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public async Task<IActionResult> AddFavoriteProduct([FromBody] FavoriteDto favoriteDto)
    {
        string? userName=_contextAccessor.HttpContext?.User.Identity?.Name;
        var user= await _userManager.Users.Include(x=>x.FavoriteProducts).FirstOrDefaultAsync(x => x.UserName == userName);
        var dto=await _productDataService.GetByIdAsync(favoriteDto.ProductId);
        var product=_mapper.Map<Product>(dto.Data);
        if (user.FavoriteProducts.Count==0) 
        {
            user.FavoriteProducts=new List<Product>();
        }
        if (user.FavoriteProducts.FirstOrDefault(x => x.Id == product.Id) == null)
        {
            user.FavoriteProducts.Add(product);
        }
        IdentityResult identityResult = await _userManager.UpdateAsync(user);
        if (identityResult.Succeeded)
           return CreateActionResult(CustomResponseDto<bool>.Success(200,true));
       return CreateActionResult(CustomResponseDto<bool>.Success(200, false));
    }

    [HttpGet("[action]")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public async Task<IActionResult> GetUserFavoriteProducts()
    {
        string? userName = _contextAccessor.HttpContext?.User.Identity?.Name;
        var user = await _userManager.Users.Include(x => x.FavoriteProducts).FirstOrDefaultAsync(x => x.UserName == userName);
        var dtos = _mapper.Map<ICollection<ProductDto>>(user.FavoriteProducts);
        return CreateActionResult(CustomResponseDto<ICollection<ProductDto>>.Success(200, dtos));
    }

    [HttpPost("[action]")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public async Task<IActionResult> UpdatePassword(UpdatePasswordViewModel updatePassword)
    => CreateActionResult(await _userService.UpdatePasswordAsync(updatePassword.OldPassword,updatePassword.NewPassword));

    [HttpPut]
    [Authorize(AuthenticationSchemes = "Admin")]

    public async Task<IActionResult> UpdateUserInfo(ApplicationUserUpdateDto dto)
    => CreateActionResult(await _userService.UpdateUserInfoAsync(dto));

}
