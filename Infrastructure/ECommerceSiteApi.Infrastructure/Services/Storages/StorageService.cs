
using ECommerceSiteApi.Application.Configuration;
using ECommerceSiteApi.Application.Services.Storages;
using Microsoft.AspNetCore.Http;

namespace ECommerceSiteApi.Infrastructure.Services.Storages
{
    public class StorageService : IStorageService
    {
        private readonly IStorage _storage;


        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public string StorageName => _storage.StorageName;

        public string StoragePath => _storage.StoragePath;

        public Task DeleteFileAsync(string fileName)
        =>_storage.DeleteFileAsync(fileName);

        public List<string> GetFiles()
        =>_storage.GetFiles();

        public bool HasFile(string fileName)
        =>_storage.HasFile(fileName);

        public Task<List<(string fileName, string pathOrContainerName, string storage)>> UploadAsync(IFormFileCollection files)
        => _storage.UploadAsync(files);
    }
}
