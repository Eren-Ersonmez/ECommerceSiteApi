

using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.RefreshTokenLogin;

public class RefreshTokenLoginCommandRequest:IRequest<RefreshTokenLoginCommandResponse>
{
    public string RefreshToken { get; set; }
}
