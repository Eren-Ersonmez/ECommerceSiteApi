using AutoMapper;
using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.OrderDetailsDtos;
using ECommerceSiteApi.Application.DTOs.OrderDtos;
using ECommerceSiteApi.Application.Repositories;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Application.UnitOfWorks;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Infrastructure.Services.DataServices;

public class OrderDetailsDataService : DataService<OrderDetails, OrderDetailsDto>, IOrderDetailsDataService
{
    private readonly IOrderDetailsReadRepository _orderDetailsReadRepository;
public OrderDetailsDataService(IWriteRepository<OrderDetails> writeRepository, IReadRepository<OrderDetails> readRepository, IUnitOfWork unitOfWork, IMapper mapper,IOrderDetailsReadRepository orderDetailsReadRepository) : base(writeRepository, readRepository, unitOfWork, mapper)
    {
        _orderDetailsReadRepository = orderDetailsReadRepository;
    }

    public async Task<CustomResponseDto<IEnumerable<OrderDetailsDto>>> GetByOrderIdOrderDetailsAsync(string orderId)
    {
        var values=await _orderDetailsReadRepository.GetByOrderIdOrderDetailsAsync(orderId);
        var dtos=_mapper.Map<IEnumerable<OrderDetailsDto>>(values);
        return CustomResponseDto<IEnumerable<OrderDetailsDto>>.Success(200, dtos);
    }
}
