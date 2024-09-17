using ECommerceSiteApi.Application.DTOs.BaseFileDtos;
using FluentValidation;

namespace ECommerceSiteApi.Application.Validators.BaseFileDtoValidators
{
    public class BaseFileCreateDtoValidator:AbstractValidator<BaseFileCreateDto>
    {
        public BaseFileCreateDtoValidator()
        {
            RuleFor(x => x.FileName).NotEmpty().WithMessage("İsim boş geçilemez")
                          .NotNull().WithMessage("İsim boş geçilemez")
                          .MinimumLength(5).WithMessage("İsim en az 5 karakter olmalı");

            RuleFor(x => x.FilePath).NotEmpty().WithMessage("Dosya yolu boş geçilemez")
                          .NotNull().WithMessage("Dosya yolu boş geçilemez");

            RuleFor(x => x.Storage).NotEmpty().WithMessage("Depolama adı boş geçilemez")
                          .NotNull().WithMessage("Depolama adı boş geçilemez");

        }
    }
}
