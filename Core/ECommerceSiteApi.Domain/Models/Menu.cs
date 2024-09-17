

using ECommerceSiteApi.Domain.Models.Common;

namespace ECommerceSiteApi.Domain.Models;

public class Menu:BaseEntity
{
    public string Name { get; set; }
    public ICollection<Endpoint> Endpoints { get; set; }
}
