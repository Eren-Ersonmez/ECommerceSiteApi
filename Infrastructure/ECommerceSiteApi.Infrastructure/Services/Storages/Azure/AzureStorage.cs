using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ECommerceSiteApi.Application.Configuration;
using ECommerceSiteApi.Application.Services.Storages.Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ECommerceSiteApi.Infrastructure.Services.Storages.Azure
{
    public class AzureStorage :Storage,IAzureStorage
    {
        readonly BlobServiceClient _blobServiceClient;
        BlobContainerClient _containerClient;
        private readonly string azureBaseUrl;

        public AzureStorage(IConfiguration configuration)
        {
            this._blobServiceClient = new(configuration["Storage:Azure"]);
            _containerClient = this._blobServiceClient.GetBlobContainerClient(StoragePath);
            azureBaseUrl = configuration["StorageBaseUrls:Azure"];
        }

        public string StorageName => StorageType.Azure.ToString();

        public string StoragePath => "product";

        public async Task DeleteFileAsync(string fileName)
        {
            try
            {
                BlobClient blobClient = _containerClient.GetBlobClient(fileName);
                if (await blobClient.ExistsAsync())
                {
                    await blobClient.DeleteAsync();
                }
                else
                {
                    Console.WriteLine($"Blob '{fileName}' does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the blob: {ex.Message}");
            }
        }

        public List<string> GetFiles()
        =>_containerClient.GetBlobs().Select(x=>x.Name).ToList();


        public bool HasFile(string fileName)
        => _containerClient.GetBlobs().Any(x => x.Name == fileName);

        public async Task<List<(string fileName, string pathOrContainerName,string storage)>> UploadAsync(IFormFileCollection files)
        {
            List<(string fileName, string pathOrContainerName, string storage)> values=new();
            try
            {
                await _containerClient.CreateIfNotExistsAsync();
                await _containerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);
                foreach (IFormFile file in files)
                {
                    string fileNewName = FileRename(file);
                    BlobClient blobClient = _containerClient.GetBlobClient(fileNewName);
                    await blobClient.UploadAsync(file.OpenReadStream());
                    values.Add((fileNewName, azureBaseUrl+"/"+StoragePath+"/"+fileNewName, StorageName));
                }
            }
            catch (Exception ex) 
            {
                return null;
            }
           
            return values;
        }
    }
}
