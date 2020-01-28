using FluentValidation;
using Rating.Core.Models;
using Shared.Core.Utilities.Enums;

namespace Rating.Core.Validators
{
    public class RatingDtoValidator : AbstractValidator<RatingDto>
    {
        public RatingDtoValidator()
        {
            RuleFor(c => c.Rate).NotEmpty().WithMessage(((int)RatingErrorsCodeEnum.ValidationRateRequired).ToString());
            RuleFor(c => c.EntityId).NotEmpty().WithMessage(((int)RatingErrorsCodeEnum.ValidationEntityIdRequired).ToString());
            RuleFor(c => c.EntityTypeId).NotEmpty().WithMessage(((int)RatingErrorsCodeEnum.ValidationEntityTypeRequired).ToString());
        }
    }
}
