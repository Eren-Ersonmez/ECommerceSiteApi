using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.Categories.DeleteCategory;

public class DeleteCategoryCommandRequest:IRequest<DeleteCategoryCommandResponse>
{
    public string Id { get; set; }
}
