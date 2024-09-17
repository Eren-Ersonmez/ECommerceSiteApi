

using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.Services.DataServices;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.PasswordReset;

public class PasswordResetCommandHandler : IRequestHandler<PasswordResetCommandRequest, PasswordResetCommandResponse>
{
    private readonly IUserService _userService;

    public PasswordResetCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<PasswordResetCommandResponse> Handle(PasswordResetCommandRequest request, CancellationToken cancellationToken)
    {
        await _userService.PasswordResetAsync(request.Email);
        return new PasswordResetCommandResponse() {CustomResponseDto=CustomResponseDto<NoContentDto>.Success(200)};
    }
}
