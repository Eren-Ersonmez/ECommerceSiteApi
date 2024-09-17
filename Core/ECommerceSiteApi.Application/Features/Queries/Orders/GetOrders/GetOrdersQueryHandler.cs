

using ECommerceSiteApi.Application.DTOs.OrderDtos;
using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Orders.GetOrders;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQueryRequest, GetOrdersQueryResponse>
{
    private readonly IOrderDataService _orderService;

    public GetOrdersQueryHandler(IOrderDataService orderService)
    => _orderService = orderService;
  

    public async Task<GetOrdersQueryResponse> Handle(GetOrdersQueryRequest request, CancellationToken cancellationToken)
    => new (){ CustomResponseDto = await _orderService.GetAllAsync(new Pagination { Page = request.Page, PageSize = request.PageSize})};
}
