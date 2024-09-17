

using ECommerceSiteApi.Application.Repositories;
using ECommerceSiteApi.Application.Services.RoleServices;
using ECommerceSiteApi.Domain.Models;
using ECommerceSiteApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSiteApi.Persistence.Repositories;

public class EndpointReadRepository : ReadRepository<Endpoint>, IEndpointReadRepository
{
    private readonly IRoleService _roleService;
    public EndpointReadRepository(ApplicationDbContext context,IRoleService roleService) : base(context)
    {
        _roleService = roleService;
    }

    public async Task<IEnumerable<string>> GetSelectedRolesOfEndpoint(string endpointCode)
    {
        Endpoint endpoint= await _query.Include(x=>x.Roles).FirstOrDefaultAsync(x=>x.Code==endpointCode);
        if (endpoint == null)
        {
            return new List<string>();
        }
        return endpoint.Roles.Select(x=>x.Name);
    }
}
