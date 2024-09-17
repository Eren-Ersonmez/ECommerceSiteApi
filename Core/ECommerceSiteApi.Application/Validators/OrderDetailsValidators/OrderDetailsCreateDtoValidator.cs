

using ECommerceSiteApi.Application.DTOs.OrderDetailsDtos;
using FluentValidation;

namespace ECommerceSiteApi.Application.Validators.OrderDetailsValidators;

public class OrderDetailsCreateDtoValidator:AbstractValidator<OrderDetailsCreateDto>
{
    public OrderDetailsCreateDtoValidator()
    {
        RuleFor(x => x.ProductId).NotNull().WithMessage("Ürün ID boş geçilemez")
                                   .NotEmpty().WithMessage("Ürün ID boş geçilemez");

        RuleFor(x => x.Price).NotNull().WithMessage("Ürün fiyatı boş geçilemez")
                           .NotEmpty().WithMessage("Ürün fiyatı boş geçilemez")
                           .GreaterThanOrEqualTo(0).WithMessage("Ürün fiyatı 0'dan küçük olamaz");

        RuleFor(x => x.Count).NotNull().WithMessage("Ürün miktarı boş geçilemez")
                           .NotEmpty().WithMessage("Ürün miktarı boş geçilemez")
                           .GreaterThanOrEqualTo(0).WithMessage("Ürün miktarı 0'dan küçük olamaz");
    }
}
