
using Microsoft.AspNetCore.Identity;

namespace ECommerceSiteApi.Domain.Models;

public class ApplicationUser:IdentityUser<string>
{
    public string Name { get; set; }
    public string Surname { get; set; }  
    public DateTime? BirthDay { get; set; }
    public string? Gender { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenEndDate { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public ICollection<CreditCard> CreditCards { get; set; }
    public ICollection<Iban> Ibans { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Product> FavoriteProducts { get; set; }
}
