using ECommerceSiteApi.Application.DTOs.CreditCardDtos;
using FluentValidation;

namespace ECommerceSiteApi.Application.Validators.CreditCardDtoValidators
{
    public class CreditCardCreateDtoValidator:AbstractValidator<CreditCardCreateDto>
    {
        public CreditCardCreateDtoValidator()
        {
            RuleFor(x => x.CardName).NotEmpty().WithMessage("İsim boş geçilemez")
                          .NotNull().WithMessage("İsim boş geçilemez")
                          .MinimumLength(5).WithMessage("İsim en az 5 karakter olmalı");

            RuleFor(x => x.CardNumber).NotNull().WithMessage("Kart numarası boş geçilemez")
                                    .NotEmpty().WithMessage("Kart numarası boş geçilemez")
                                    .CreditCard().WithMessage("Lütfen geçerli bir kart numarası giriniz");

            RuleFor(x => x.ExpirationDateMonth).NotNull().WithMessage("Son kullanma ayı boş geçilemez")
                                     .NotEmpty().WithMessage("Son kullanma ayı boş geçilemez")
                                     .InclusiveBetween(1, 12).WithMessage("Lütfen geçerli son kullanma ayı giriniz");

            RuleFor(x => x.ExpirationDateYear).NotNull().WithMessage("Son kullanma yılı boş geçilemez")
                                    .NotEmpty().WithMessage("Son kullanma yılı boş geçilemez")
                                    .InclusiveBetween(1, 29).WithMessage("Lütfen geçerli son kullanma yılı giriniz");

            RuleFor(x => x.Cvc).NotNull().WithMessage("Cvc boş geçilemez")
                                    .NotEmpty().WithMessage("Cvc boş geçilemez")
                                    .Length(16).WithMessage("Cvc 3 karakter olmalıdır.");

        }
    }
}
