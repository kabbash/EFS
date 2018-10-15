using FluentValidation;
using Products.Categories.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Categories.Core.Validators
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
