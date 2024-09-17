

namespace ECommerceSiteApi.Application.DTOs.ApplicationUserDtos;

public class ApplicationUserUpdateDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDay { get; set; }
    public string Gender { get; set; }
    public virtual string? PhoneNumber { get; set; }
}
