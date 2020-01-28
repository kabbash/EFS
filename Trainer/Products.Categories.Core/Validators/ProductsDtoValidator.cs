using FluentValidation;
using Products.Core.Models;
using Shared.Core.Utilities.Enums;

namespace Products.Core.Validators
{
    public class ProductsDtoValidator : AbstractValidator<ProductsDto>
    {
        public ProductsDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(((int)ProductsErrorsCodeEnum.ValidationProductNameRequired).ToString());
            RuleFor(c => c.Price).NotEmpty().WithMessage(((int)ProductsErrorsCodeEnum.ValidationPriceRequired).ToString());
            RuleFor(c => c.CategoryId).NotEmpty().WithMessage(((int)ProductsErrorsCodeEnum.ValidationProductCategoryRequired).ToString());
        }
    }
}
