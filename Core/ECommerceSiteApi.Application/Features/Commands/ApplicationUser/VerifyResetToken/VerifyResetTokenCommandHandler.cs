

using ECommerceSiteApi.Application.Services.DataServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.VerifyResetToken;

public class VerifyResetTokenCommandHandler : IRequestHandler<VerifyResetTokenCommandRequest, VerifyResetTokenCommandResponse>
{
    private readonly IUserService _userService;

    public VerifyResetTokenCommandHandler(IUserService userService)
    =>_userService = userService;
    

    public async Task<VerifyResetTokenCommandResponse> Handle(VerifyResetTokenCommandRequest request, CancellationToken cancellationToken)
    => new() {CustomResponseDto= await _userService.VerifyResetTokenAsync(request.ResetToken, request.UserId) };
    
}
