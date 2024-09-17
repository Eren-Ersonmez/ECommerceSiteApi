using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Products.GetCategoryProducts;

public class GetCategoryProductsQueryRequest:IRequest<GetCategoryProductsQueryResponse>
{
    public string CategoryId { get; set; }
}