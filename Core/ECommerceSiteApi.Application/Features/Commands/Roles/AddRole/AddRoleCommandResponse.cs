using ECommerceSiteApi.Application.DTOs.ProductDtos;
using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Domain.Models;

namespace ECommerceSiteApi.Application.Features.Commands.Roles.AddRole;

public class AddRoleCommandResponse
{
    public CustomResponseDto<bool> CustomResponseDto { get; set; }
}