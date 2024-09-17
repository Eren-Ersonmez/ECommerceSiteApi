using ECommerceSiteApi.Application.Constants;
using ECommerceSiteApi.Application.CustomAttributes;
using ECommerceSiteApi.Application.DTOs.CreditCardDtos;
using ECommerceSiteApi.Application.Enums;
using ECommerceSiteApi.Application.Features.Commands.Addresses.AddAddress;
using ECommerceSiteApi.Application.Features.Commands.CreditCards.AddCreditCard;
using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSiteApi.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Admin")]
    public class CreditCardsController : CustomBaseController
    {
        private readonly IDataService<CreditCard,CreditCardDto> _creditCardService;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreditCardsController(IDataService<CreditCard, CreditCardDto> creditCardService, IMediator mediator, IHttpContextAccessor contextAccessor, UserManager<ApplicationUser> userManager)
        {
            _creditCardService = creditCardService;
            _mediator = mediator;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        [HttpGet]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.CreditCards, ActionType = ActionType.Reading, Defination = " Get Credit Cards")]
        public async Task<IActionResult> GetCreditCards([FromQuery] Pagination pagination)
        => CreateActionResult(await _creditCardService.GetAllAsync(pagination));

        [HttpGet("{id}")]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.CreditCards, ActionType = ActionType.Reading, Defination = " Get Credit Card")]
        public async Task<IActionResult> GetCreditCard(string id)
        =>CreateActionResult(await _creditCardService.GetByIdAsync(id));

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserCreditCards()
        {
            string? userName = _contextAccessor.HttpContext?.User.Identity?.Name;
            ApplicationUser? user=await _userManager.Users.FirstOrDefaultAsync(x=>x.UserName==userName);
            var dto= await _creditCardService.WhereAsync(x => x.ApplicationUserId == user.Id);
            return CreateActionResult(dto);

        }


        [HttpPost]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.CreditCards, ActionType = ActionType.Writing, Defination = " Add Credit Card")]
        public async Task<IActionResult> AddCreditCard(AddCreditCardCommandRequest request)
        =>CreateActionResult((await _mediator.Send(request)).CustomResponseDto);

        [HttpDelete("{id}")]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.CreditCards, ActionType = ActionType.Deleting, Defination = "Delete Credit Card")]
        public async Task<IActionResult> DeleteCreditCard(string id)
        =>CreateActionResult(await _creditCardService.DeleteAsync(id));

        [HttpPut]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.CreditCards, ActionType = ActionType.Writing, Defination = "Update Credit Card")]
        public async Task<IActionResult> UpdateCreditCard(CreditCardUpdateDto dto)
        =>CreateActionResult(await _creditCardService.UpdateAsync(dto));
    }
}
