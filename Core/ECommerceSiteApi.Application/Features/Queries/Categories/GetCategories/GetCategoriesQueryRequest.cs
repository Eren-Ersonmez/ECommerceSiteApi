
using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Categories.GetCategories;

public class GetCategoriesQueryRequest:IRequest<GetCategoriesQueryResponse>
{
    public int Page { get; set; } = 0;
    public int PageSize { get; set; } = 5;
}
