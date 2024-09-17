using ECommerceSiteApi.Application.Features.Commands.ApplicationUser.ExternalLogin;
using ECommerceSiteApi.Application.Features.Commands.ApplicationUser.Login;
using ECommerceSiteApi.Application.Features.Commands.ApplicationUser.PasswordReset;
using ECommerceSiteApi.Application.Features.Commands.ApplicationUser.RefreshTokenLogin;
using ECommerceSiteApi.Application.Features.Commands.ApplicationUser.UpdatePassword;
using ECommerceSiteApi.Application.Features.Commands.ApplicationUser.VerifyResetToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSiteApi.Api.Controllers;

public class AuthController : CustomBaseController
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    => _mediator = mediator;

    [HttpPost("[action]")]
    public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginCommandRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);
    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginCommandRequest request)
   => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

    [HttpPost("[action]")]
    public async Task<IActionResult> ExternalLogin(ExternalLoginCommandRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

    [HttpPost("[action]")]
    public async Task<IActionResult> PasswordReset(PasswordResetCommandRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

    [HttpPost("[action]")]
    public async Task<IActionResult> VerifyResetToken(VerifyResetTokenCommandRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

    [HttpPost("[action]")]
    public async Task<IActionResult> UpdatePassword(UpdatePasswordCommandRequest request)
    => CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

}
