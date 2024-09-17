

using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Products.GetProductsWithCategory
{
    public class GetProductsWithCategoryQueryRequest:IRequest<GetProductsWithCategoryQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 5;
    }
}
