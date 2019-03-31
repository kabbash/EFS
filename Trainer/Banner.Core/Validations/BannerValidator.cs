using Banner.Core.Models;
using FluentValidation;
using Shared.Core.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banner.Core.Validations
{
    public class BannerValidator : AbstractValidator<BannerDto>
    {
        public BannerValidator()
        {
            RuleFor(b => b.Title).NotEmpty().WithMessage(((int)BannersErrorsCodeEnum.ValidationTitleRequired).ToString());
            RuleFor(b => b.ImageFile).NotEmpty().WithMessage(((int)BannersErrorsCodeEnum.ValidationImageRequired).ToString());
            RuleFor(b => b.ButtonText).NotEmpty().WithMessage(((int)BannersErrorsCodeEnum.ValidationButtonTextRequired).ToString());
            RuleFor(b => b.ButtonUrl).NotEmpty().WithMessage(((int)BannersErrorsCodeEnum.ValidationButtonURLRequired).ToString());
        }
    }
}
