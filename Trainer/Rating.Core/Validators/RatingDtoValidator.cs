using FluentValidation;
using Rating.Core.Models;

namespace Rating.Core.Validators
{
    public class RatingDtoValidator : AbstractValidator<RatingDto>
    {
        public RatingDtoValidator()
        {
            RuleFor(c => c.Rate).NotEmpty();
            RuleFor(c => c.Comment).NotEmpty();
            RuleFor(c => c.ItemsForReviewId).NotEmpty();
            RuleFor(c => c.EntityTypeId).NotEmpty();
        }
    }
}
