

using Microsoft.AspNetCore.Identity;

namespace ECommerceSiteApi.Domain.Models;

public class AppRole:IdentityRole<string>
{
    public ICollection<Endpoint> Endpoints { get; set; }
}
