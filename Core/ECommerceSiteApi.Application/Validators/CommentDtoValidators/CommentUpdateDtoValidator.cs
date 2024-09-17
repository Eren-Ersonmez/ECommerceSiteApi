using ECommerceSiteApi.Application.DTOs.CommentDtos;
using FluentValidation;

namespace ECommerceSiteApi.Application.Validators.CommentDtoValidators
{
    public class CommentUpdateDtoValidator:AbstractValidator<CommentUpdateDto>
    {
        public CommentUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id boş geçilemez")
                         .NotNull().WithMessage("Id boş geçilemez");

            RuleFor(x => x.CommentContent).NotEmpty().NotEmpty().WithMessage("Yorum içeriği boş geçilemez")
                           .NotNull().WithMessage("Yorum içeriği boş geçilemez")
                           .MinimumLength(10).WithMessage("Yorum içeriği en az 5 karakter olmalı");
        }
    }
}
