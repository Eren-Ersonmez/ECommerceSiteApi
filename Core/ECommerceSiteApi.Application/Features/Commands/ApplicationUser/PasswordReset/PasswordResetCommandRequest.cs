

using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.PasswordReset;

public class PasswordResetCommandRequest:IRequest<PasswordResetCommandResponse>
{
    public string Email { get; set; }
}
