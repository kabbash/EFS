using FluentValidation;
using OTraining.Core.Models;
using Shared.Core.Utilities.Enums;

namespace OTraining.Core.Validators
{
    public class ProgramDtoValidator : AbstractValidator<OTrainingProgramDto>
    {
        public ProgramDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(((int)OTrainingErrorsCodeEnum.ValidationDescriptionRequired).ToString());
            RuleFor(c => c.Features).NotEmpty().WithMessage(((int)OTrainingErrorsCodeEnum.ValidationProgramFeaturesRequired).ToString());
        }
    }
}
