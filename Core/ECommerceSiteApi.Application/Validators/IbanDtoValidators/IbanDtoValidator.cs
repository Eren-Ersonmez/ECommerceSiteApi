using ECommerceSiteApi.Application.DTOs.IbanDtos;
using FluentValidation;

namespace ECommerceSiteApi.Application.Validators.IbanDtoValidators
{
    public class IbanDtoValidator:AbstractValidator<IbanDto>
    {
        public IbanDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Kredi kart ID boş geçilemez")
                           .NotNull().WithMessage("Kredi kart ID boş geçilemez");

            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş geçilemez")
                            .NotNull().WithMessage("İsim boş geçilemez")
                            .MinimumLength(5).WithMessage("İsim en az 5 karakter olmalı");

            RuleFor(x => x.IbanNumber).NotEmpty().WithMessage("İsim boş geçilemez")
                            .NotNull().WithMessage("İsim boş geçilemez")
                            .Length(26).WithMessage("Iban numarası 26 karakter olmalı");

            RuleFor(x => x.ApplicationUserId).NotEmpty().WithMessage("Kullanıcı ID boş geçilemez")
                           .NotNull().WithMessage("Kullanıcı ID boş geçilemez");

        }
    }
}
