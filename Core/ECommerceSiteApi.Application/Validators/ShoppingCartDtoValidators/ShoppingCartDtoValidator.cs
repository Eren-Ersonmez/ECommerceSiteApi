using ECommerceSiteApi.Application.DTOs.ShoppingCartDtos;
using FluentValidation;

namespace ECommerceSiteApi.Application.Validators.ShoppingCartDtoValidators
{
    public class ShoppingCartDtoValidator:AbstractValidator<ShoppingCartDto>
    {
        public ShoppingCartDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Sepet ID boş geçilemez")
                           .NotEmpty().WithMessage("Sepet ID boş geçilemez");

            RuleFor(x => x.ProductId).NotNull().WithMessage("Ürün ID boş geçilemez")
                                     .NotEmpty().WithMessage("Ürün ID boş geçilemez");

            RuleFor(x => x.ApplicationUserId).NotNull().WithMessage("Kullanıcı ID boş geçilemez")
                                     .NotEmpty().WithMessage("Kullanıcı ID boş geçilemez");

            RuleFor(x => x.Price).NotNull().WithMessage("Ürün fiyatı boş geçilemez")
                               .NotEmpty().WithMessage("Ürün fiyatı boş geçilemez")
                               .GreaterThanOrEqualTo(0).WithMessage("Ürün fiyatı 0'dan küçük olamaz");

            RuleFor(x => x.Count).NotNull().WithMessage("Ürün miktarı boş geçilemez")
                               .NotEmpty().WithMessage("Ürün miktarı boş geçilemez")
                               .GreaterThanOrEqualTo(0).WithMessage("Ürün miktarı 0'dan küçük olamaz");

        }
    }
}
