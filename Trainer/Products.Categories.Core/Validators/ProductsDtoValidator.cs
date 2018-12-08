using FluentValidation;
using Products.Core.Models;

namespace Products.Core.Validators
{
    public class ProductsDtoValidator : AbstractValidator<ProductsDto>
    {
        public ProductsDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.ProfilePicture).NotEmpty();
            RuleFor(c => c.ExpDate).NotEmpty();
            RuleFor(c => c.Price).NotEmpty();
            RuleFor(c => c.ProdDate).NotEmpty();
            RuleFor(c => c.CategoryId).NotEmpty();
        }
    }
}
