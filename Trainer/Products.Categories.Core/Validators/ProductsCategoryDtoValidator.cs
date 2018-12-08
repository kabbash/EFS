using FluentValidation;
using Products.Core.Models;

namespace Products.Core.Validators
{
    public class ProductsCategoryDtoValidator : AbstractValidator<ProductsCategoryDto>
    {
        public ProductsCategoryDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.ProfilePicture).NotEmpty();
        }
    }
}
