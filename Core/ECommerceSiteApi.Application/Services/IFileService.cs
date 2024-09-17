
using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.BaseFileDtos;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using Microsoft.AspNetCore.Http;
namespace ECommerceSiteApi.Application.Services
{
    public interface IFileService<File,FileDto>:IDataService<File,FileDto> where File:BaseFile  where FileDto : BaseFileDto
    {
        Task<CustomResponseDto<NoContentDto>> UploadAsync<T>(IFormFileCollection files, Dictionary<string, object> additionalProperties = null) where T : BaseFileCreateDto, new();
        Task<CustomResponseDto<bool>> RemoveAsync(string id);
    }
}
