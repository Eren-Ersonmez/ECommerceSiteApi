using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.OrderDetailsDtos;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Services.DataServices;

public interface IOrderDetailsDataService: IDataService<OrderDetails, OrderDetailsDto>
{
    Task<CustomResponseDto<IEnumerable<OrderDetailsDto>>> GetByOrderIdOrderDetailsAsync(string orderId);
}
