using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using test.core.Model;

namespace test.core.Validators
{
    public class CaloriesDtoValidator : AbstractValidator<CaloriesDto>
    {
        public CaloriesDtoValidator()
        {
            RuleFor(model => model.Name).NotEmpty();
            RuleFor(model => model.Value).NotEmpty();
            RuleFor(model => model.Description).NotEmpty().EmailAddress();
        }
    }
}
