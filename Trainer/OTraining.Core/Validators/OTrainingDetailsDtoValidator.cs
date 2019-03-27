using FluentValidation;
using OTraining.Core.Models;

namespace OTraining.Core.Validators
{
    public class OTrainingDetailsDtoValidator : AbstractValidator<OTrainingDetailsDto>
    {
        public OTrainingDetailsDtoValidator()
        {
            RuleFor(c => c.Description).NotEmpty().MinimumLength(10);
            RuleFor(c => c.ForJoin).NotEmpty().MinimumLength(10);
        }
    }
}
