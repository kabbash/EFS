using Articles.Core.Models;
using FluentValidation;

namespace Articles.Core.Validators
{
    public class ArticleAddDtoValidator: AbstractValidator<ArticleAddDto>
    {
        public ArticleAddDtoValidator()
        {
            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.Description).NotEmpty();
            //RuleFor(a => a.CategoryId).NotEmpty();
        }
    }
}
