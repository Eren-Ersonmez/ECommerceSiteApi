
using ECommerceSiteApi.Application.Services.Storages;
using Microsoft.AspNetCore.Http;

namespace ECommerceSiteApi.Infrastructure.Services.Storages
{
    public class Storage
    {
        public string FileRename(IFormFile file)
        {
            return Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        }
    }
}
