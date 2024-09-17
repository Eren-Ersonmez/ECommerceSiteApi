

namespace ECommerceSiteApi.Application.DTOs.CreditCardDtos
{
    public class CreditCardDto:BaseDto
    {
        public Guid Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public int ExpirationDateMonth { get; set; }
        public int ExpirationDateYear { get; set; }
        public string Cvc { get; set; }

    }
}
