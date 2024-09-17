using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.UpdatePassword;

public class UpdatePasswordCommandRequest:IRequest<UpdatePasswordCommandResponse>
{
    public string ResetToken {  get; set; }
    public string UserId { get; set; }
    public string NewPassword { get; set; }
}