using ECommerceSiteApi.Application.DTOs.CategoryDtos;
using FluentValidation;

namespace ECommerceSiteApi.Application.Validators.CategoryDtoValidators
{
    public class CategoryUpdateDtoValidator:AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Kategori ID boş geçilemez")
                        .NotNull().WithMessage("Kategori ID boş geçilemez");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori ismi boş geçilemez")
                              .NotNull().WithMessage("Kategori ismi boş geçilemez")
                              .MinimumLength(3).WithMessage("Kategori ismi en az 5 karakter olmalı");

        }
    }
}
