

using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.Login;

public class LoginCommandRequest:IRequest<LoginCommandResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
