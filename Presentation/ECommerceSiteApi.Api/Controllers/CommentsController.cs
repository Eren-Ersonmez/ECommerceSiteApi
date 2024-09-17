using ECommerceSiteApi.Application.DTOs.CommentDtos;
using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSiteApi.Api.Controllers
{

    public class CommentsController : CustomBaseController
    {
        private readonly ICommentDataService _commentDataService;
        public CommentsController(ICommentDataService commentDataService)
        {
            _commentDataService = commentDataService;
        }
        [HttpGet]
        public async Task<IActionResult> GetComments([FromQuery] Pagination pagination)
        => CreateActionResult(await _commentDataService.GetAllAsync(pagination));
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(string id)
        => CreateActionResult(await _commentDataService.GetByIdAsync(id));

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductComments([FromQuery]string productId)
        => CreateActionResult(await _commentDataService.GetAllProductCommentsAsync(productId));
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> AddComment(CommentCreateDto dto)
        => CreateActionResult(await _commentDataService.AddCommentAsync(dto));
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        => CreateActionResult(await _commentDataService.DeleteAsync(id));
        
        [HttpPut]
        public async Task<IActionResult> Update(CommentUpdateDto dto)
        => CreateActionResult(await _commentDataService.UpdateAsync(dto));

        [HttpPut("[action]")]
        public async Task<IActionResult> LikedComment([FromQuery]string id)
        => CreateActionResult(await _commentDataService.LikedCommentAsync(id));
        
        
    }
}
