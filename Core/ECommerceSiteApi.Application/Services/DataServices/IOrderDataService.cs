
using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.OrderDtos;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Services.DataServices;

public interface IOrderDataService : IDataService<Order, OrderDto>
{
    Task<CustomResponseDto<OrderDto>> GetOrderWithModelsAsync(string id);
    Task<CustomResponseDto<bool>> UpdateOrderStatusAsync(string orderId, string orderStatus);
}
