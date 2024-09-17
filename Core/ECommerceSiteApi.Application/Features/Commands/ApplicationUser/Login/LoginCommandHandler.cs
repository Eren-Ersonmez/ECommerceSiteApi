using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.Services.LoginServices;
using MediatR;
namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
 
    private readonly IInternalLoginService _internalLoginService;

    public LoginCommandHandler(IInternalLoginService internalLoginService)
    =>_internalLoginService = internalLoginService;
    

    public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    => new LoginCommandResponse() { CustomResponseDto = await _internalLoginService.LoginAsync(request.Email,request.Password) };
    
}
