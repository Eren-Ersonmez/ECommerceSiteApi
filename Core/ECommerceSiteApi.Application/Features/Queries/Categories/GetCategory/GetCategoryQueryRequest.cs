

using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Categories.GetCategory;

public class GetCategoryQueryRequest:IRequest<GetCategoryQueryResponse>
{
    public string Id { get; set; }
}
