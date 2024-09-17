
using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ECommerceSiteApi.Application.Features.Commands.ApplicationUser.AddApplicationUser;

public class AddApplicationUserCommandHandler : IRequestHandler<AddApplicationUserCommandRequest, AddApplicationUserCommandResponse>
{
    private readonly IUserService _userService;

    public AddApplicationUserCommandHandler(IUserService userService)
    => _userService = userService;
    

    public async Task<AddApplicationUserCommandResponse> Handle(AddApplicationUserCommandRequest request, CancellationToken cancellationToken)
    => new() {CustomResponseDto= await _userService.AddUserAsync(request.Dto) };
       
    
}
