using FluentValidation;
using OTraining.Core.Models;

namespace OTraining.Core.Validators
{
    public class ProgramDtoValidator : AbstractValidator<OTrainingProgramDto>
    {
        public ProgramDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Features).NotEmpty().MinimumLength(10);
        }
    }
}
