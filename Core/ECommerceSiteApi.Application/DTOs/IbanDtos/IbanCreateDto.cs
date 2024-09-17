
namespace ECommerceSiteApi.Application.DTOs.IbanDtos
{
    public class IbanCreateDto:BaseDto
    {
        public string? ApplicationUserId { get; set; }
        public string Name { get; set; }
        public string IbanNumber { get; set; }
    }


}
