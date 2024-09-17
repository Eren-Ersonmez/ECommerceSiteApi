

using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.CreditCardDtos;

namespace ECommerceSiteApi.Application.Features.Commands.CreditCards.AddCreditCard;

public class AddCreditCardCommandResponse
{
    public CustomResponseDto<CreditCardDto> CustomResponseDto { get; set; }
}
