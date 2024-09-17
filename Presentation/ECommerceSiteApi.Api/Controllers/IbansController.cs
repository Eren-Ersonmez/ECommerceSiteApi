using ECommerceSiteApi.Application.DTOs.IbanDtos;
using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static QRCoder.PayloadGenerator.SwissQrCode;

namespace ECommerceSiteApi.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Admin")]
    public class IbansController : CustomBaseController
    {
        private readonly IDataService<Domain.Models.Iban,IbanDto> _ibanService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public IbansController(IDataService<Domain.Models.Iban, IbanDto> ibanService, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _ibanService = ibanService;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> GetIbans([FromQuery] Pagination pagination)
        => CreateActionResult(await _ibanService.GetAllAsync(pagination));

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserIbans()
        {
            string? userName = _contextAccessor.HttpContext?.User.Identity?.Name;
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            return CreateActionResult(await _ibanService.WhereAsync(x=>x.ApplicationUserId==user.Id));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIban(string id)
        => CreateActionResult(await _ibanService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> AddIban(IbanCreateDto iban)
        {
            string? userName = _contextAccessor.HttpContext?.User.Identity?.Name;
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            iban.ApplicationUserId=user.Id;
            return CreateActionResult(await _ibanService.AddAsync(iban));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIban(string id)
        => CreateActionResult(await _ibanService.DeleteAsync(id));

        [HttpPut]
        public async Task<IActionResult> UpdateIban(IbanUpdateDto iban)
        => CreateActionResult(await _ibanService.UpdateAsync(iban));
    }
}
