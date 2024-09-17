

using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.Features.Commands.ApplicationUser.ExternalLogin;
using ECommerceSiteApi.Application.Services.LoginService.FacebookLogin;
using ECommerceSiteApi.Application.Services.LoginService.GoogleLogin;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.GoogleLogin;

public class ExternalLoginCommandHandler : IRequestHandler<ExternalLoginCommandRequest, ExternalLoginCommandResponse>
{
    private readonly IGoogleLoginService _googleService;
    private readonly IFacebookLoginService _facebookLoginService;

    public ExternalLoginCommandHandler(IGoogleLoginService googleService,IFacebookLoginService facebookLoginService)
    {
        _googleService = googleService;
        _facebookLoginService = facebookLoginService;
    } 
    

    public async Task<ExternalLoginCommandResponse> Handle(ExternalLoginCommandRequest request, CancellationToken cancellationToken)
    {
        Token token=null;
        if (request.Provider=="GOOGLE")
        {
             token = await _googleService.ValidateTokenAsync(request);
        }
        else if (request.Provider == "FACEBOOK")
        {
            token=await _facebookLoginService.ValidateTokenAsync(request);
        }
        if (token != null) 
        {
            return new() { CustomResponseDto = CustomResponseDto<Token>.Success(201, token) };
        }
        return new() { CustomResponseDto = CustomResponseDto<Token>.Fail(400, "Olmayan bir login isteği..") };
    }
}
