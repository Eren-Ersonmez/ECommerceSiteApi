using Microsoft.AspNetCore.Http;

namespace ECommerceSiteApi.Application.Services.Storages
{
    public interface IStorage
    {
        public string StorageName { get; }
        public string StoragePath { get; }
        Task<List<(string fileName, string pathOrContainerName,string storage)>> UploadAsync(IFormFileCollection files);

        Task DeleteFileAsync(string fileName);
        List<string> GetFiles();
        bool HasFile(string fileName);
    }
}
