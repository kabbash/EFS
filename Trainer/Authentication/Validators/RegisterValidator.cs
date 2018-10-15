using Authentication.Models;
using FluentValidation;

namespace Authentication.Validators
{
    public class RegisterValidator: AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(model => model.Email).NotEmpty().EmailAddress();
            RuleFor(model => model.FirstName).NotEmpty();
            RuleFor(model => model.LastName).NotEmpty();
            RuleFor(model => model.Password).NotEmpty();


        }
    }
}
