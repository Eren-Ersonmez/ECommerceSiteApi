using ECommerceSiteApi.Application.DTOs.ProductImageFileDtos;
using FluentValidation;

namespace ECommerceSiteApi.Application.Validators.ProductImageFileDtoValidators
{
    public class ProductImageFileDtoValidator:AbstractValidator<ProductImageFileDto>
    {
        public ProductImageFileDtoValidator()
        {
           
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Ürün Id boş geçilemez")
                       .NotNull().WithMessage("Ürün Id boş geçilemez");
        }
    }
}
