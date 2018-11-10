using FluentValidation;
using Rating.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rating.Core.Validators
{
    public class RatingDtoValidator : AbstractValidator<RatingDto>
    {
        public RatingDtoValidator()
        {
            RuleFor(c => c.Rate).NotEmpty();
            RuleFor(c => c.Comment).NotEmpty();
            RuleFor(c => c.EntityId).NotEmpty();
            RuleFor(c => c.EntityTypeId).NotEmpty();
        }
    }
}
