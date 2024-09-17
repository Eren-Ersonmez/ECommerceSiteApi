using ECommerceSiteApi.Application.DTOs.CreditCardDtos;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSiteApi.Application.Features.Commands.CreditCards.AddCreditCard;

public class AddCreditCardCommandHandler : IRequestHandler<AddCreditCardCommandRequest, AddCreditCardCommandResponse>
{
    private readonly IDataService<CreditCard,CreditCardDto> _creditCardService;
    private readonly UserManager<Domain.Models.ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AddCreditCardCommandHandler(IDataService<CreditCard, CreditCardDto> creditCardService, UserManager<Domain.Models.ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _creditCardService = creditCardService;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<AddCreditCardCommandResponse> Handle(AddCreditCardCommandRequest request, CancellationToken cancellationToken)
    {
        string? userName = _httpContextAccessor.HttpContext.User.Identity?.Name;
        if (userName != null)
        {
            Domain.Models.ApplicationUser? user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            CreditCardDto dto = new CreditCardDto()
            {
                CardName = request.CreateDto.CardName,
                CardNumber = request.CreateDto.CardNumber,
                Cvc = request.CreateDto.Cvc,
                ExpirationDateMonth = request.CreateDto.ExpirationDateMonth,
                ExpirationDateYear = request.CreateDto.ExpirationDateYear,
                ApplicationUserId = user.Id
            };
            return new() {CustomResponseDto = await _creditCardService.AddAsync(dto)};

        }
        throw new Exception("User not found");
    }
}
