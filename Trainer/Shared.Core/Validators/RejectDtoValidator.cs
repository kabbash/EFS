using FluentValidation;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Models;

namespace Shared.Core.Validators
{
    public class RejectDtoValidator : AbstractValidator<RejectDto>
    {
        public RejectDtoValidator()
        {            
            RuleFor(a => a.Id).NotEmpty().WithMessage(((int)SharedErrorsCodeEnum.ValidationRejectIdRequired).ToString());
            RuleFor(a => a.RejectReason).NotEmpty().WithMessage(((int)SharedErrorsCodeEnum.ValidationRejectReasonRequired).ToString());
        }
    }
}
