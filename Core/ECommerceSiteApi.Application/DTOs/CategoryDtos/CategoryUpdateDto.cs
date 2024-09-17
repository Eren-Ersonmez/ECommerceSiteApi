

namespace ECommerceSiteApi.Application.DTOs.CategoryDtos
{
    public class CategoryUpdateDto:BaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
