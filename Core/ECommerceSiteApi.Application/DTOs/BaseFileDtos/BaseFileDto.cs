

namespace ECommerceSiteApi.Application.DTOs.BaseFileDtos
{
    public class BaseFileDto:BaseDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Storage { get; set; }

    }
}
