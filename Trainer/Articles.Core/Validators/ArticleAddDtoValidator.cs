using Articles.Core.Models;
using FluentValidation;
using Shared.Core.Utilities.Enums;

namespace Articles.Core.Validators
{
    public class ArticleAddDtoValidator: AbstractValidator<ArticleAddDto>
    {
        public ArticleAddDtoValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage(((int)ArticlesErrorsCodeEnum.ValidationsArticleNameRequired).ToString());
            RuleFor(a => a.Description).NotEmpty().WithMessage(((int)ArticlesErrorsCodeEnum.ValidationsArticleDescRequired).ToString());
        }
    }
}
