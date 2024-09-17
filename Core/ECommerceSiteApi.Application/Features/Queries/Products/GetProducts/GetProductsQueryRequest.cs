using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Products.GetProducts;

public class GetProductsQueryRequest : IRequest<GetProductsQueryResponse>
{
    public int Page { get; set; } = 0;
    public int PageSize { get; set; } = 5;
}
