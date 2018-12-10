using FluentValidation;
using ItemsReview.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemsReview.Validators
{
    public class ItemReviewDtoValidator : AbstractValidator<ItemReviewDto>
    {
        public ItemReviewDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
