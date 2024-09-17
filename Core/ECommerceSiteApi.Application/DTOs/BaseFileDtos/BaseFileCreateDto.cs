

namespace ECommerceSiteApi.Application.DTOs.BaseFileDtos
{
    public class BaseFileCreateDto : BaseDto
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Storage { get; set; }

    }
}
