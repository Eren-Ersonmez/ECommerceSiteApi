

using ECommerceSiteApi.Application.DTOs.OrderDtos;
using FluentValidation;

namespace ECommerceSiteApi.Application.Validators.OrderDtoValidators
{
    public class OrderDtoValidator:AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Sipariş ID boş geçilemez")
                          .NotNull().WithMessage("Sipariş ID boş geçilemez");


            RuleFor(x => x.AddressId).NotEmpty().WithMessage("Adres ID boş geçilemez")
                            .NotNull().WithMessage("Adres ID boş geçilemez");

            RuleFor(x => x.CreditCardId).NotEmpty().WithMessage("Kredi Kart ID boş geçilemez")
                            .NotNull().WithMessage("Kredi Kart ID boş geçilemez");


            RuleFor(x => x.OrderStatus).NotEmpty().WithMessage("Sipariş tarihi boş geçilemez")
                                     .NotNull().WithMessage("Sipariş tarihi boş geçilemez");

            RuleFor(x => x.OrderTotal).NotEmpty().WithMessage("Sipariş tutarı boş geçilemez")
                                      .NotNull().WithMessage("Sipariş tutarı boş geçilemez")
                                      .GreaterThan(0).WithMessage("Sipariş tutarı 0'dan büyük olmalı");

            RuleForEach(x => x.OrderDetailIds).NotEmpty().WithMessage("Sipariş detayı boş geçilemez")
                                           .NotNull().WithMessage("Sipariş detayı boş geçilemez");
        }
    }
}
