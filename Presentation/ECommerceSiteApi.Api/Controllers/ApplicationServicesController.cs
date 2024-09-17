using ECommerceSiteApi.Application.Constants;
using ECommerceSiteApi.Application.CustomAttributes;
using ECommerceSiteApi.Application.Enums;
using ECommerceSiteApi.Application.Features.Commands.ApplicationSevices.AssociateRoleAndEndpoint;
using ECommerceSiteApi.Application.Features.Commands.ApplicationSevices.GetSelectedRolesOfEndpoint;
using ECommerceSiteApi.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace ECommerceSiteApi.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ApplicationServicesController : CustomBaseController
    {
        private readonly IConfigurationService _configurationService;
        private readonly IMediator _mediator;

        public ApplicationServicesController(IConfigurationService configurationService,IMediator mediator)
        {
            _configurationService = configurationService;
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.ApplicationServices, ActionType = ActionType.Reading, Defination = "Get Authorize Definition Endpoints")]
        public async Task<IActionResult> GetAuthorizeDefinitionEndpoints()
        {
            var datas =_configurationService.GetAuthorizeDefinationEndpoints(typeof(Program));
            return Ok(datas);
        }
        [HttpPost]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.ApplicationServices, ActionType = ActionType.Writing, Defination = "Associate Role And Endpoint")]
        public async Task<IActionResult> AssociateRoleAndEndpoint(AssociateRoleAndEndpointCommandRequest request)
        {
            request.Type = typeof(Program);
            return CreateActionResult((await _mediator.Send(request)).CustomResponseDto);
        }
        [HttpPost("[action]")]
        [AuthorizeDefination(Menu = AuthorizeDefinationCustom.ApplicationServices, ActionType = ActionType.Writing, Defination = "Get Selected Roles Of Endpoint")]
        public async Task<IActionResult> GetSelectedRolesOfEndpoint(GetSelectedRolesOfEndpointCommandRequest request)
        {
           return CreateActionResult((await _mediator.Send(request)).CustomResponseDto);
        }

    }
}
