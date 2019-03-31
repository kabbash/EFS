using FluentValidation;
using Products.Core.Models;
using Shared.Core.Utilities.Enums;

namespace Products.Core.Validators
{
    public class ProductsCategoryDtoValidator : AbstractValidator<ProductsCategoryDto>
    {
        public ProductsCategoryDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(((int)ProductsErrorsCodeEnum.ValidationProductNameRequired).ToString());
            RuleFor(c => c.ProfilePicture).NotEmpty().WithMessage(((int)ProductsErrorsCodeEnum.ValidationProductImageRequired).ToString());
        }
    }
}
