using ECommerceSiteApi.Application.DTOs.CategoryDtos;
using ECommerceSiteApi.Application.Validators.ProductDtoValidators;
using FluentValidation;

namespace ECommerceSiteApi.Application.Validators.CategoryDtoValidators
{
    public class CategoryDtoValidator:AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Kategori ID boş geçilemez")
                         .NotNull().WithMessage("Kategori ID boş geçilemez");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori ismi boş geçilemez")
                              .NotNull().WithMessage("Kategori ismi boş geçilemez")
                              .MinimumLength(3).WithMessage("Kategori ismi en az 5 karakter olmalı");

            RuleForEach(x => x.Products).NotEmpty().WithMessage("Ürün bilgisi boş geçilemez")
                                      .NotNull().WithMessage("Ürün bilgisi boş geçilemez")
                                      .SetValidator(new ProductDtoValidator());

        }
    }
}
