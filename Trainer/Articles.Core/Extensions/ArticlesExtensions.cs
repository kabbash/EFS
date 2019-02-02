using Articles.Core.Models;
using Shared.Core.Utilities.Enums;
using System.Linq;

namespace Articles.Core.Extensions
{
    public static class ArticlesExtensions
    {
        public static IQueryable<Shared.Core.Models.Articles> ApplyFilter(this IQueryable<Shared.Core.Models.Articles> articles, ArticlesFilter filter)
        {
            if (filter == null)
                return articles;

            switch ((StatusFilterEnum)filter.Status)
            {
                case StatusFilterEnum.Active:
                    articles = articles.Where(c => c.IsActive == true);
                    break;
                case StatusFilterEnum.Rejected:
                    articles = articles.Where(c => c.IsActive == false);
                    break;
                case StatusFilterEnum.Pending:
                    articles = articles.Where(c => !c.IsActive.HasValue);
                    break;
            }

            if (filter.CategoryId != 0)
                articles = articles.Where(c => c.CategoryId == filter.CategoryId);

            if (!string.IsNullOrEmpty(filter.SearchText))
                articles = articles.Where(c => c.Name.ToLower().Contains(filter.SearchText.ToLower()));

            return articles;
        }
    }
}
