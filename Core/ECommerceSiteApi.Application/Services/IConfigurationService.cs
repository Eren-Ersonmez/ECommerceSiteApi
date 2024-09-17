

using ECommerceSiteApi.Application.DTOs.ConfigurationDtos;

namespace ECommerceSiteApi.Application.Services;

public interface IConfigurationService
{
    List<Menu> GetAuthorizeDefinationEndpoints(Type assemblyType);
}
