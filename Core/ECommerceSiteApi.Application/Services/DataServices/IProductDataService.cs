using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.ProductDtos;
using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Application.ViewModels;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Services.DataServices;

public interface IProductDataService:IDataService<Product,ProductDto>
{
    Task<CustomResponseDto<IEnumerable<ProductsWithCategoryViewModel>>> GetAllWithCategoryAsync(Pagination pagination);
    Task<CustomResponseDto<ProductDto>> GetProductWithImagesAsync(string id);
    Task<CustomResponseDto<Byte[]>> QRCodeToProductAsync(string productId);
    Task<CustomResponseDto<bool>> UpdateStockQrCodeToProduct(string productId, int stock);
}
