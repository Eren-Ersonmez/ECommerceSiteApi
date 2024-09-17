

using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.ApplicationUserDtos;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerceSiteApi.Application.Features.Queries.ApplicationUsers.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQueryRequest, GetUsersQueryResponse>
{
    private readonly IUserService _userService;

    public GetUsersQueryHandler(IUserService userService)
    => _userService = userService;
    

    public async Task<GetUsersQueryResponse> Handle(GetUsersQueryRequest request, CancellationToken cancellationToken)
    => new() { CustomResponseDto =await _userService.GetUsersAsync(new() {Page=request.Page,PageSize=request.PageSize})};
        
    
}
