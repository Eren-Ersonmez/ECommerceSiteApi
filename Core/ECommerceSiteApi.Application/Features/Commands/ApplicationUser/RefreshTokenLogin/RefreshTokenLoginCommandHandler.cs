

using ECommerceSiteApi.Application.Services.LoginServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.RefreshTokenLogin;

public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
{
    private readonly IInternalLoginService _internalLoginService;

    public RefreshTokenLoginCommandHandler(IInternalLoginService internalLoginService)
    => _internalLoginService = internalLoginService;
    

    public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
    => new() {CustomResponseDto= await _internalLoginService.RefreshTokenLogin(request.RefreshToken) };
    
}
