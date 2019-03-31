using FluentValidation;
using ItemsReview.Models;
using Shared.Core.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemsReview.Validators
{
    public class ItemReviewDtoValidator : AbstractValidator<ItemReviewDto>
    {
        public ItemReviewDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(((int)ItemsReviewsErrorsCodeEnum.ValidationNameRequired).ToString());
        }
    }
}
