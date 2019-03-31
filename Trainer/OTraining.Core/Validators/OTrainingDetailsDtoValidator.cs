using FluentValidation;
using OTraining.Core.Models;
using Shared.Core.Utilities.Enums;

namespace OTraining.Core.Validators
{
    public class OTrainingDetailsDtoValidator : AbstractValidator<OTrainingDetailsDto>
    {
        public OTrainingDetailsDtoValidator()
        {
            RuleFor(c => c.Description).NotEmpty().WithMessage(((int)OTrainingErrorsCodeEnum.ValidationDescriptionRequired).ToString());
            RuleFor(c => c.ForJoin).NotEmpty().WithMessage(((int)OTrainingErrorsCodeEnum.ValidationForJoinRequired).ToString());
        }
    }
}
