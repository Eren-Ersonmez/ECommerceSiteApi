
using AutoMapper;
using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.ShoppingCartDtos;
using ECommerceSiteApi.Application.Repositories;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Application.UnitOfWorks;
using ECommerceSiteApi.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSiteApi.Infrastructure.Services.DataServices;

public class ShoppingCartDataService : DataService<ShoppingCart, ShoppingCartDto>, IShoppingCartDataService
{
    private readonly IShoppingCartReadRepository _shoppingCartReadRepository;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IProductReadRepository _productReadRepository;
    public ShoppingCartDataService(
        IWriteRepository<ShoppingCart> writeRepository,
        IReadRepository<ShoppingCart> readRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IShoppingCartReadRepository shoppingCartReadRepository,
        UserManager<ApplicationUser> userManager,
        IHttpContextAccessor httpContextAccessor,
        IProductReadRepository productReadRepository
        )
     : base(writeRepository, readRepository, unitOfWork, mapper)
    {
        _shoppingCartReadRepository = shoppingCartReadRepository;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
        _productReadRepository = productReadRepository;
    }

    public async Task<CustomResponseDto<IEnumerable<ShoppingCartDto>>> GetUsersShoppingCartsAsync()
    {
        string? userName =_httpContextAccessor.HttpContext.User.Identity?.Name;
        if (userName != null) 
        { 
          ApplicationUser? user=await _userManager.FindByNameAsync(userName);
          var carts=await _shoppingCartReadRepository.GetUsersShoppingCartsAsync(user.Id);
          foreach (var cart in carts) 
          { 
            cart.Product=await _productReadRepository.GetByIdAsync(cart.ProductId.ToString());
          }
          var dtos = _mapper.Map<IEnumerable<ShoppingCartDto>>(carts);
          return CustomResponseDto<IEnumerable<ShoppingCartDto>>.Success(200, dtos);
        }
        return CustomResponseDto<IEnumerable<ShoppingCartDto>>.Fail(500, "User not found");
    }

    public async Task<CustomResponseDto<bool>> UpdateShoppingCartsAsync(ShoppingCartUpdateDto shoppingCart)
    {
        string? userName = _httpContextAccessor.HttpContext?.User.Identity?.Name;
        if (userName != null) 
        {
            ApplicationUser? user = await _userManager.FindByNameAsync(userName);
            var cart = await _shoppingCartReadRepository.Where(x=>x.ApplicationUserId==user.Id).FirstOrDefaultAsync();
            if (cart != null) 
            {
                cart.ApplicationUser = user;
                cart.Price=shoppingCart.Price;
                cart.Count=shoppingCart.Count;
                cart.ApplicationUserId = user.Id;
                cart.ProductId=shoppingCart.ProductId;
                cart.Product=await _productReadRepository.GetByIdAsync(cart.ProductId.ToString());
                var result=_writeRepository.Update(cart);
                await _unitOfWork.CommitAsync();
                return CustomResponseDto<bool>.Success(200, result);
            }
            else
            {
                return CustomResponseDto<bool>.Fail(500, "ShoppingCart not found");
            }
        }
        return CustomResponseDto<bool>.Fail(500, "User not found");
    }
}
