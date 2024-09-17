using ECommerceSiteApi.Application.DTOs.CommentDtos;
using FluentValidation;

namespace ECommerceSiteApi.Application.Validators.CommentDtoValidators
{
    public class CommentDtoValidator:AbstractValidator<CommentDto>
    {
        public CommentDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id boş geçilemez")
                         .NotNull().WithMessage("Id boş geçilemez");

            RuleFor(x => x.CommentContent).NotEmpty().NotEmpty().WithMessage("Yorum içeriği boş geçilemez")
                           .NotNull().WithMessage("Yorum içeriği boş geçilemez")
                           .MinimumLength(10).WithMessage("Yorum içeriği en az 5 karakter olmalı");

            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Ürün id boş geçilemez")
                                  .NotNull().WithMessage("Ürün id boş geçilemez");

        }
    }
}
