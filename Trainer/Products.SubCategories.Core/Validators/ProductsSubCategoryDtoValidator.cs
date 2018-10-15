using FluentValidation;
using Products.SubCategories.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.SubCategories.Core.Validators
{
    public class ProductsSubCategoryDtoValidator : AbstractValidator<ProductsSubCategoryDto>
    {
        public ProductsSubCategoryDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.ProfilePicture).NotEmpty();
            RuleFor(c => c.CategoryId).NotEmpty();
        }
    }
}
