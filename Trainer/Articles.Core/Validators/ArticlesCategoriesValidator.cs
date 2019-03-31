using Articles.Core.Models;
using FluentValidation;
using Shared.Core.Utilities.Enums;

namespace Articles.Core.Validators
{
    public class ArticlesCategoriesValidator: AbstractValidator<ArticlesCategoriesDto>
    {
        public ArticlesCategoriesValidator()
        {
            RuleFor(model => model.Name).NotEmpty().WithMessage(((int)ArticlesErrorsCodeEnum.ValidationsCategoryNameRequired).ToString()); ;
        }
    }
}
