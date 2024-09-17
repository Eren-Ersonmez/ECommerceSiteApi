using AutoMapper;
using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.OrderDtos;
using ECommerceSiteApi.Application.Repositories;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Application.UnitOfWorks;
using ECommerceSiteApi.Domain.Constants;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Infrastructure.Services.DataServices;

public class OrderDataService : DataService<Order, OrderDto>, IOrderDataService
{
    private readonly IOrderReadRepository _orderReadRepository;
    public OrderDataService(IWriteRepository<Order> writeRepository, IReadRepository<Order> readRepository, IUnitOfWork unitOfWork, IMapper mapper,IOrderReadRepository orderReadRepository) : base(writeRepository, readRepository, unitOfWork, mapper)
    {
        _orderReadRepository = orderReadRepository;
    }

    public async Task<CustomResponseDto<OrderDto>> GetOrderWithModelsAsync(string id)
    {
        var values= await _orderReadRepository.GetOrderWithModels(id);
        var dtos= _mapper.Map<OrderDto>(values);
        return CustomResponseDto<OrderDto>.Success(200, dtos);
    }
    public async Task<CustomResponseDto<bool>> UpdateOrderStatusAsync(string orderId,string orderStatus)
    {
        switch (orderStatus)
        {
            case OrderStatus.WaitingForOrderConfirmation:
                orderStatus = OrderStatus.OrderIsBeingPrepared;
                break;
            case OrderStatus.OrderIsBeingPrepared:
                orderStatus= OrderStatus.HasBeenShipped;
                break;
            case OrderStatus.HasBeenShipped:
                orderStatus=OrderStatus.Delivered;
                break;
            default:
                break;
        }
            Order order = await _orderReadRepository.GetByIdAsync(orderId);
            order.OrderStatus = orderStatus;
            await _unitOfWork.CommitAsync();
        return CustomResponseDto<bool>.Success(200,true);
    }
}
