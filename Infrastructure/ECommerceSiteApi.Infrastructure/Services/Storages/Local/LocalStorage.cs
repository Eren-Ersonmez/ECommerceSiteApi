using ECommerceSiteApi.Application.Services.Storages.Local;
using Microsoft.AspNetCore.Http;
using ECommerceSiteApi.Application.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
namespace ECommerceSiteApi.Infrastructure.Services.Storages.Local
{
    public class LocalStorage : Storage,ILocalStorage
    {
        private readonly string uploadPath;
        private readonly IConfiguration _configuration;

        public LocalStorage(string uploadPath,IConfiguration configuration)
        {
            this.uploadPath = uploadPath;
            _configuration = configuration;
        }

        public string StorageName => StorageType.Local.GetType().Name;

        public string StoragePath => this.uploadPath;

        public async Task DeleteFileAsync(string fileName)
        {
            if (System.IO.File.Exists(Path.Combine(uploadPath,fileName)))
            {
                System.IO.File.Delete(Path.Combine(uploadPath, fileName));
            }
        }

        public List<string> GetFiles()
        {
            DirectoryInfo directory = new(uploadPath);
            return directory.GetFiles().Select(x=>x.Name).ToList();
        }

        public bool HasFile(string fileName)
        => File.Exists(Path.Combine(uploadPath,fileName));
        public async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }
        

        public async Task<List<(string fileName, string pathOrContainerName, string storage)>> UploadAsync(IFormFileCollection files)
        {

            List<(string fileName, string path, string storage)> list = new();
            foreach (IFormFile file in files)
            {
                string fileNewName = FileRename(file);
                await CopyFileAsync(Path.Combine(uploadPath, fileNewName), file);
                int index = Path.Combine(uploadPath, fileNewName).IndexOf("wwwroot");
                string baseUrl = _configuration["BaseUrl"];
                string path =$"{baseUrl}{Path.Combine(uploadPath, fileNewName).Substring(index + 7)}";
                list.Add((fileNewName, path, this.StorageName));
            }
            return list;
        }
    }
}
