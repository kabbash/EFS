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

        }
    }
}
