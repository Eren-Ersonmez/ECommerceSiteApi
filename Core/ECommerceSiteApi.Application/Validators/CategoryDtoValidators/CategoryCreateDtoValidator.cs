using ECommerceSiteApi.Application.DTOs.CategoryDtos;
using FluentValidation;

namespace ECommerceSiteApi.Application.Validators.CategoryDtoValidators
{
    public class CategoryCreateDtoValidator:AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori ismi boş geçilemez")
                            .NotNull().WithMessage("Kategori ismi boş geçilemez");

        }
    }
}
