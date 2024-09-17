

using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Comments.GetProductComment;

public class GetProductCommentsQueryHandler : IRequestHandler<GetProductCommentsQueryRequest, GetProductCommentsQueryResponse>
{
    public Task<GetProductCommentsQueryResponse> Handle(GetProductCommentsQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
