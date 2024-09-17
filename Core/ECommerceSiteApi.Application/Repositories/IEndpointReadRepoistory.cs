
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Repositories;

public interface IEndpointReadRepository: IReadRepository<Endpoint>
{
   Task<IEnumerable<string>>  GetSelectedRolesOfEndpoint(string endpointCode);
}
