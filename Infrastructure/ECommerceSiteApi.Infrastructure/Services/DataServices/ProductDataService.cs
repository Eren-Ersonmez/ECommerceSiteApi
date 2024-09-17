using AutoMapper;
using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.ProductDtos;
using ECommerceSiteApi.Application.Repositories;
using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Application.Services;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Application.UnitOfWorks;
using ECommerceSiteApi.Application.ViewModels;
using ECommerceSiteApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ECommerceSiteApi.Infrastructure.Services.DataServices
{
    public class ProductDataService : DataService<Product, ProductDto>, IProductDataService
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IQRCodeService _qrCodeService;
        public ProductDataService(IWriteRepository<Product> writeRepository, IReadRepository<Product> readRepository, IUnitOfWork unitOfWork, IMapper mapper, IProductReadRepository productReadRepository,IQRCodeService qRCodeService) : base(writeRepository, readRepository, unitOfWork, mapper)
        {
            _productReadRepository = productReadRepository;
            _qrCodeService = qRCodeService;
        }

        public async Task<CustomResponseDto<IEnumerable<ProductsWithCategoryViewModel>>> GetAllWithCategoryAsync(Pagination pagination)
        {
            int dataTotalCount =await _productReadRepository.DataTable.CountAsync();
            var values=await _productReadRepository.GetAllWithCategoryAsync(pagination);
            var dtos=_mapper.Map<IEnumerable<ProductsWithCategoryViewModel>>(values);
            return CustomResponseDto<IEnumerable<ProductsWithCategoryViewModel>>.Success(204,dtos,dataTotalCount);
        }

        public async Task<CustomResponseDto<ProductDto>> GetProductWithImagesAsync(string id)
        {
            Product product = await _productReadRepository.GetProductWithImagesAsync(id);
            ProductDto productDto =_mapper.Map<ProductDto>(product);
            return CustomResponseDto<ProductDto>.Success(200, productDto);  
        }

        public async Task<CustomResponseDto<byte[]>> QRCodeToProductAsync(string productId)
        {
            Product product=await _productReadRepository.GetByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found");
            var plainObject = new
            {
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.stock,
                product.CreatedDate,

            };
            string plainText=JsonSerializer.Serialize(plainObject); 

           byte[] qrCodeBytes= _qrCodeService.GenerateQRCode(plainText);
           return CustomResponseDto<byte[]>.Success(201, qrCodeBytes);
        }

        public async Task<CustomResponseDto<bool>> UpdateStockQrCodeToProduct(string productId, int stock)
        {
            Product product=await _productReadRepository.GetByIdAsync(productId);
            product.stock = stock;
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<bool>.Success(200,true);
        }
    }
}
