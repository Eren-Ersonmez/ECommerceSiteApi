﻿using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.VerifyResetToken;

public class VerifyResetTokenCommandRequest:IRequest<VerifyResetTokenCommandResponse>
{
    public string ResetToken { get; set; }
    public string UserId { get; set; }
}