using ECommerceSiteApi.Application.DTOs.CategoryDtos;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Domain.Models;
using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.Categories.AddCategory;

public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommandRequest, AddCategoryCommandResponse>
{
    private readonly IDataService<Category, CategoryDto> _dataService;

    public AddCategoryCommandHandler(IDataService<Category, CategoryDto> dataService)
    => _dataService = dataService;


    async Task<AddCategoryCommandResponse> IRequestHandler<AddCategoryCommandRequest, AddCategoryCommandResponse>.Handle(AddCategoryCommandRequest request, CancellationToken cancellationToken)
    => new() { CustomResponseDto = await _dataService.AddAsync(request.CreateDto) };

}
