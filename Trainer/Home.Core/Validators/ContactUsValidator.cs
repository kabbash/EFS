using FluentValidation;
using Home.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Core.Validators
{
    public class ContactUsValidator : AbstractValidator<ContactUsDto>
    {
        public ContactUsValidator()
        {
            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.Email).NotEmpty();
            RuleFor(a => a.Details).NotEmpty();
            RuleFor(a => a.PhoneNumber).NotEmpty();            
        }
    }
}
