

using MediatR;

namespace ECommerceSiteApi.Application.Features.Queries.Products.GetProduct
{
    public class GetProductQueryRequest:IRequest<GetProductQueryResponse>
    {
        public string Id { get; set; }
    }
}
