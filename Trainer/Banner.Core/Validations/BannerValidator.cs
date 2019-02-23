using Banner.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banner.Core.Validations
{
    public class BannerValidator: AbstractValidator<BannerDto>
    {
        public BannerValidator()
        {
            RuleFor(b => b.Title).NotEmpty();
            RuleFor(b => b.ImageFile).NotEmpty();
            RuleFor(b => b.ButtonText).NotEmpty().When(b => !string.IsNullOrEmpty(b.ButtonUrl));
            RuleFor(b => b.ButtonUrl).NotEmpty().When(b => !string.IsNullOrEmpty(b.ButtonText));

        }
    }
}
