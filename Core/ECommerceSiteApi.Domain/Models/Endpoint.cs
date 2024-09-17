

using ECommerceSiteApi.Domain.Models.Common;

namespace ECommerceSiteApi.Domain.Models;

public class Endpoint:BaseEntity
{
    public Endpoint()
    {
        Roles=new HashSet<AppRole>();
    }
    public Guid MenuId { get; set; }
    public Menu Menu { get; set; }
    public string ActionType { get; set; }
    public string HttpType { get; set; }
    public string Definition {  get; set; } 
    public string Code { get; set; }
    public ICollection<AppRole> Roles { get; set; }
}
