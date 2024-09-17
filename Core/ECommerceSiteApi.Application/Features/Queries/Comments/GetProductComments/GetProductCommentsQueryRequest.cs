using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Comments.GetProductComment;

public class GetProductCommentsQueryRequest:IRequest<GetProductCommentsQueryResponse>
{
    public string ProductId { get; set; }
}