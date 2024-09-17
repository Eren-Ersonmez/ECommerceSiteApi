using ECommerceSiteApi.Application.DTOs.OrderDtos;
using ECommerceSiteApi.Application.Validators.AddressDtoValidators;
using ECommerceSiteApi.Application.Validators.CreditCardDtoValidators;
using FluentValidation;

namespace ECommerceSiteApi.Application.Validators.OrderDtoValidators
{
    public class OrderCreateDtoValidator:AbstractValidator<OrderCreateDto>
    {
        public OrderCreateDtoValidator()
        {
            RuleFor(x => x.AddressId).NotEmpty().WithMessage("Adres boş geçilemez")
                         .NotNull().WithMessage("Adres boş geçilemez");

            RuleFor(x => x.CreditCardId).NotEmpty().WithMessage("Kredi Kart boş geçilemez");


            RuleFor(x => x.OrderTotal).NotEmpty().WithMessage("Sipariş tutarı boş geçilemez")
                                      .NotNull().WithMessage("Sipariş tutarı boş geçilemez")
                                      .GreaterThan(0).WithMessage("Sipariş tutarı 0'dan büyük olmalı");


        }
    }
}
