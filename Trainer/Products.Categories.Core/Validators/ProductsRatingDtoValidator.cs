using FluentValidation;
using Products.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Core.Validators
{
    public class ProductsRatingDtoValidator : AbstractValidator<ProductsRatingDto>
    {
        public ProductsRatingDtoValidator()
        {
            RuleFor(c => c.Rate).NotEmpty();
            RuleFor(c => c.Comment).NotEmpty();
            RuleFor(c => c.ProductId).NotEmpty();
        }
    }
}
