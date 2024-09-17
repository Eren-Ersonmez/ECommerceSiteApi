

using ECommerceSiteApi.Application.DTOs.CreditCardDtos;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.CreditCards.AddCreditCard;

public class AddCreditCardCommandRequest:IRequest<AddCreditCardCommandResponse>
{
    public CreditCardCreateDto CreateDto { get; set; } 
}
