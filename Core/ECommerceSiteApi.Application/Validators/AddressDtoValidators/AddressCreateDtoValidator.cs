using ECommerceSiteApi.Application.DTOs.AddressDtos;
using FluentValidation;


namespace ECommerceSiteApi.Application.Validators.AddressDtoValidators
{
    public class AddressCreateDtoValidator : AbstractValidator<AddressCreateDto>
    {
        public AddressCreateDtoValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Adres bilgisi boş geçilemez")
                                 .NotNull().WithMessage("Adres bilgisi boş geçilemez")
                                 .MinimumLength(10).WithMessage("Adres bilgisi en az 10 karakterolmalı");

            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir kısmı boş geçilemez")
                                .NotNull().WithMessage("Şehir kısmı boş geçilemez")
                                .MinimumLength(3).WithMessage("Şehir bilgisinin karkater uzunluğu en az 3 karakter olamlı")
                                .MaximumLength(14).WithMessage("Şehir bilgisinin karakter uzunluğu en fazla 13 karakter olmalı");

            RuleFor(x => x.District).NotEmpty().WithMessage("İlçe kısmı boş geçilemez")
                                .NotNull().WithMessage("İlçe kısmı boş geçilemez")
                                .MinimumLength(3).WithMessage("İlçe bilgisinin karakter uzunluğu en az 3 karakter olamlı")
                                .MaximumLength(16).WithMessage("İlçe bilgisinin karakter uzunluğu en fazla 13 karakter olmalı");

            RuleFor(x => x.PostalCode).NotEmpty().WithMessage("Posta kodu kısmı boş geçilemez")
                                .NotNull().WithMessage("Posta kodu kısmı boş geçilemez")
                                .Must(x =>
                                {
                                    return x.Length == 5;
                                }).WithMessage("Posta kodu 5 karakter olmalı");
        }

    }
}
