using FluentValidation;
using Home.Core.Models;
using Shared.Core.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Core.Validators
{
    public class ContactUsValidator : AbstractValidator<ContactUsDto>
    {
        public ContactUsValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage(((int)HomeErrorsCodeEnum.ValidationNameRequired).ToString());
            RuleFor(a => a.Email).NotEmpty().WithMessage(((int)HomeErrorsCodeEnum.ValidationEmailRequired).ToString());
            RuleFor(a => a.Email).EmailAddress().WithMessage(((int)HomeErrorsCodeEnum.ValidationEmailInvalid).ToString());
            RuleFor(a => a.Details).NotEmpty().WithMessage(((int)HomeErrorsCodeEnum.ValidationDetailsRequired).ToString());
            RuleFor(a => a.PhoneNumber).NotEmpty().WithMessage(((int)HomeErrorsCodeEnum.ValidationPhoneNumRequired).ToString());
        }
    }
}
