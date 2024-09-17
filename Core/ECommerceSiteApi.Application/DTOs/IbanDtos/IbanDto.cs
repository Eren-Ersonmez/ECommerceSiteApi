

namespace ECommerceSiteApi.Application.DTOs.IbanDtos
{
    public class IbanDto : BaseDto
    {
        public Guid Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string Name { get; set; }
        public string IbanNumber { get; set; }

    }
}
