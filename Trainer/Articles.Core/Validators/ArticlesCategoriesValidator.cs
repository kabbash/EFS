using Articles.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.Core.Validators
{
    public class ArticlesCategoriesValidator: AbstractValidator<ArticlesCategoriesDto>
    {
        public ArticlesCategoriesValidator()
        {
            RuleFor(model => model.Name).NotEmpty();
            RuleFor(model => model.ProfilePicture).NotEmpty();
        }
    }
}
