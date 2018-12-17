using Articles.Core.Models;
using FluentValidation;

namespace Articles.Core.Validators
{
    public class ArticlesCategoriesValidator: AbstractValidator<ArticlesCategoriesDto>
    {
        public ArticlesCategoriesValidator()
        {
            RuleFor(model => model.Name).NotEmpty();
            // RuleFor(model => model.ProfilePictureFile).NotEmpty();
        }
    }
}
