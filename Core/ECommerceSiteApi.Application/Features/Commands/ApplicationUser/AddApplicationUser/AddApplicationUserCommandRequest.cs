
using ECommerceSiteApi.Application.DTOs.ApplicationUserDtos;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.AddApplicationUser;

public class AddApplicationUserCommandRequest:IRequest<AddApplicationUserCommandResponse>
{
    public ApplicationUserCreateDto Dto { get; set; }
}
