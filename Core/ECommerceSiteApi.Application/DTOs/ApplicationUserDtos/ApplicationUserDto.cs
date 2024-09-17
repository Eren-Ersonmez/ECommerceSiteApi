

namespace ECommerceSiteApi.Application.DTOs.ApplicationUserDtos;

public class ApplicationUserDto:BaseDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public virtual string? Email { get; set; }
    public virtual string? UserName { get; set; }
    public string? Role { get; set; }
}
