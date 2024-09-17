using ECommerceSiteApi.Application.DTOs.CommentDtos;
using FluentValidation;

namespace ECommerceSiteApi.Application.Validators.CommentDtoValidators
{
    public class CommentCreateDtoValidator:AbstractValidator<CommentCreateDto>
    {
        public CommentCreateDtoValidator()
        {
            RuleFor(x => x.CommentContent).NotEmpty().NotEmpty().WithMessage("Yorum içeriği boş geçilemez")
                        .NotNull().WithMessage("Yorum içeriği boş geçilemez")
                        .MinimumLength(10).WithMessage("Yorum içeriği en az 5 karakter olmalı");

            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Ürün id boş geçilemez")
                                  .NotNull().WithMessage("Ürün id boş geçilemez");

        }
    }
}
