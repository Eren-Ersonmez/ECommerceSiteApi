using ECommerceSiteApi.Application.DTOs.IbanDtos;
using FluentValidation;

namespace ECommerceSiteApi.Application.Validators.IbanDtoValidators
{
    public class IbanUpdateDtoValidator:AbstractValidator<IbanUpdateDto>
    {
        public IbanUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID boş geçilemez")
                         .NotNull().WithMessage("ID boş geçilemez");

            RuleFor(x => x.Name).NotEmpty().NotEmpty().WithMessage("İsim boş geçilemez")
                            .NotNull().WithMessage("İsim boş geçilemez")
                            .MinimumLength(5).WithMessage("İsim en az 5 karakter olmalı");

            RuleFor(x => x.IbanNumber).NotEmpty().NotEmpty().WithMessage("İsim boş geçilemez")
                            .NotNull().WithMessage("İsim boş geçilemez")
                            .Length(26).WithMessage("Iban numarası 26 karakter olmalı");

        }
    }
}
