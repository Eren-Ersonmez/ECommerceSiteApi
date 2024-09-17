

using AutoMapper;
using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.DTOs.CommentDtos;
using ECommerceSiteApi.Application.Repositories;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Application.UnitOfWorks;
using ECommerceSiteApi.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSiteApi.Infrastructure.Services.DataServices;

public class CommentDataService : DataService<Comment, CommentDto>, ICommentDataService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CommentDataService(IWriteRepository<Comment> writeRepository, IReadRepository<Comment> readRepository, IUnitOfWork unitOfWork, IMapper mapper,UserManager<ApplicationUser> userManager,IHttpContextAccessor httpContextAccessor) : base(writeRepository, readRepository, unitOfWork, mapper)
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<CustomResponseDto<CommentDto>> AddCommentAsync(CommentCreateDto commentDto)
    {
        string? userName = _httpContextAccessor.HttpContext.User.Identity?.Name;
        if (userName != null) 
        { 
          ApplicationUser? user=_userManager.Users.FirstOrDefault(x => x.UserName == userName);
          commentDto.ApplicationUserId = user?.Id;
          return await AddAsync(commentDto);
        }
        return CustomResponseDto<CommentDto>.Fail(400,"User not found");
        
    }

    public async Task<CustomResponseDto<IEnumerable<CommentDto>>> GetAllProductCommentsAsync(string productId)
    {
     var datas =await _readRepository.DataTable.Where(x=>x.ProductId==Guid.Parse(productId)).Include(x=>x.ApplicationUser).ToListAsync();
     var dtos=_mapper.Map<IEnumerable<CommentDto>>(datas); 
     return CustomResponseDto<IEnumerable<CommentDto>>.Success(200, dtos);
    }

    public async Task<CustomResponseDto<NoContentDto>> LikedCommentAsync(string id)
    {
        Comment comment=await _readRepository.GetByIdAsync(id);
        comment.LikeCount += 1;
        await _unitOfWork.CommitAsync();
        return CustomResponseDto<NoContentDto>.Success(200);
    }
}
