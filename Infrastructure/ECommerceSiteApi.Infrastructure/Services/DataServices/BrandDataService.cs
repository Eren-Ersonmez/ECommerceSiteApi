

using AutoMapper;
using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.BrandDtos;
using ECommerceSiteApi.Application.Repositories;
using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Application.UnitOfWorks;
using ECommerceSiteApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSiteApi.Infrastructure.Services.DataServices;

public class BrandDataService : DataService<Brand, BrandDto>,IBrandDataService
{
    public BrandDataService(IWriteRepository<Brand> writeRepository, IReadRepository<Brand> readRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(writeRepository, readRepository, unitOfWork, mapper)
    {
    }

    public async Task<CustomResponseDto<List<BrandDto>>> GetAllWithCategoryAsync(Pagination pagination)
    {
        int dataTotalCount=await _readRepository.DataTable.CountAsync();
        var values=await _readRepository.DataTable.Include(x=>x.Category).Skip(pagination.Page*pagination.PageSize).Take(pagination.PageSize).ToListAsync();
        var dtos=_mapper.Map<List<BrandDto>>(values);
        return CustomResponseDto<List<BrandDto>>.Success(200,dtos,dataTotalCount);
    }

}
