

namespace ECommerceSiteApi.Application.DTOs.AddressDtos
{
    public class AddressUpdateDto:BaseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public string AddressOwnerName { get; set; }
        public string AddressOwnerSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string ApplicationUserId { get; set; }

    }
}
