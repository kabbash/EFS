using Authentication.Models;
using FluentValidation;
using Shared.Core.Utilities.Enums;

namespace Authentication.Validators
{
    public class RegisterValidator: AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(model => model.Email).NotEmpty().WithMessage(((int)AuthenticationErrorsCodeEnum.ValidationEmailRequired).ToString());
            RuleFor(model => model.Email).EmailAddress().WithMessage(((int)AuthenticationErrorsCodeEnum.ValidationEmailRequired).ToString());                
            RuleFor(model => model.FullName).NotEmpty().WithMessage(((int)AuthenticationErrorsCodeEnum.ValidationFullNameRequired).ToString());
            RuleFor(model => model.Password).NotEmpty().WithMessage(((int)AuthenticationErrorsCodeEnum.ValidationPasswordRequired).ToString());
        }
    }
}
