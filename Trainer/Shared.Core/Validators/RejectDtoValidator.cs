using FluentValidation;
using Shared.Core.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Validators
{
    public class RejectDtoValidator : AbstractValidator<RejectDto>
    {
        public RejectDtoValidator()
        {
            RuleFor(a => a.Id).NotEmpty();
            RuleFor(a => a.RejectReason).NotEmpty();
            RuleFor(a => a.UserId).NotEmpty();
        }
    }
}
