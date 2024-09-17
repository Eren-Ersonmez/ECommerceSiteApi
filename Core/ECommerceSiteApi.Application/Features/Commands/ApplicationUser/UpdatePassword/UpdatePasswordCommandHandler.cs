

using ECommerceSiteApi.Application.Services.DataServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.UpdatePassword;

public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommandRequest, UpdatePasswordCommandResponse>
{
    private readonly IUserService _userService;

    public UpdatePasswordCommandHandler(IUserService userService)
    => _userService = userService;
    

    public async Task<UpdatePasswordCommandResponse> Handle(UpdatePasswordCommandRequest request, CancellationToken cancellationToken)
    => new() {CustomResponseDto = await _userService.UpdatePasswordAsync(request.UserId, request.ResetToken, request.NewPassword) };
    
}
