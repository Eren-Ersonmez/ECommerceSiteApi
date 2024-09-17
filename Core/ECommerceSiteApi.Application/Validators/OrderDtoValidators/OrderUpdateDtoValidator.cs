using ECommerceSiteApi.Application.DTOs.OrderDtos;
using FluentValidation;

namespace ECommerceSiteApi.Application.Validators.OrderDtoValidators
{
    public class OrderUpdateDtoValidator:AbstractValidator<OrderUpdateDto>
    {
        public OrderUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Sipariş ID boş geçilemez")
                           .NotNull().WithMessage("Sipariş ID boş geçilemez");


            RuleFor(x => x.AddressId).NotEmpty().WithMessage("Adres ID boş geçilemez")
                            .NotNull().WithMessage("Adres ID boş geçilemez")
                            .GreaterThan(0).WithMessage("Id 0 ve 0'dan küçük olamaz");


            RuleFor(x => x.OrderStatus).NotEmpty().WithMessage("Sipariş tarihi boş geçilemez")
                                     .NotNull().WithMessage("Sipariş tarihi boş geçilemez");

        }
    }
}
