using AutoMapper;
using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.BaseFileDtos;
using ECommerceSiteApi.Application.Repositories;
using ECommerceSiteApi.Application.Services;
using ECommerceSiteApi.Application.Services.Storages;
using ECommerceSiteApi.Application.UnitOfWorks;
using ECommerceSiteApi.Domain.Models;
using ECommerceSiteApi.Infrastructure.Services.DataServices;
using Microsoft.AspNetCore.Http;

namespace ECommerceSiteApi.Infrastructure.Services
{
    public class FileService<File,FileDto> :DataService<File,FileDto>,IFileService<File,FileDto> where File : BaseFile where FileDto : BaseFileDto
    {
        private readonly IStorageService _storageService;
        public FileService(IWriteRepository<File> writeRepository, IReadRepository<File> readRepository, IUnitOfWork unitOfWork, IMapper mapper, IStorageService storageService) : base(writeRepository, readRepository, unitOfWork, mapper)
        {
            _storageService = storageService;
        }


        public async Task<CustomResponseDto<bool>> RemoveAsync(string id)
        {
            try
            {
               var value= await GetByIdAsync(id);
               await _storageService.DeleteFileAsync(value.Data.FileName);
               return await DeleteAsync(id);
            }
            catch (Exception ex)
            {
               return CustomResponseDto<bool>.Fail(500,ex.Message);
            }
            
        }

        public async Task<CustomResponseDto<NoContentDto>> UploadAsync<T>(IFormFileCollection files, Dictionary<string, object> additionalProperties = null) where T : BaseFileCreateDto, new() 
        {
            List<T> dtos = new();
            var values = await _storageService.UploadAsync(files);

            foreach (var item in values)
            {
                var dto = new T
                {
                    FileName = item.fileName,
                    FilePath = item.pathOrContainerName,
                    Storage = item.storage,
                };
                if (additionalProperties != null)
                {
                   
                  foreach (var prop in additionalProperties)
                  {
                     var propertyInfo = dto.GetType().GetProperty(prop.Key);
                     if (propertyInfo != null && propertyInfo.CanWrite)
                     {
                       propertyInfo.SetValue(dto,Guid.Parse(prop.Value.ToString()));
                     }
                  }

                }

                dtos.Add(dto);
            }

            return await AddRangeAsync(dtos);
        }



    }
}
