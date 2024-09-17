

namespace ECommerceSiteApi.Application.RequestParameters
{
    public record Pagination
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
