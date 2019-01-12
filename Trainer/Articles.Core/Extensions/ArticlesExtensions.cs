using Articles.Core.Models;
using System.Linq;

namespace Articles.Core.Extensions
{
    public static class ArticlesExtensions
    {
        public static IQueryable<Shared.Core.Models.Articles> ApplyFilter(this IQueryable<Shared.Core.Models.Articles> articles, ArticlesFilter filter)
        {
            if (filter == null)
                return articles;

            switch ((ArticleStatusEnum)filter.Status)
            {
                case ArticleStatusEnum.Active:
                    articles = articles.Where(c => c.IsActive == true);
                    break;
                case ArticleStatusEnum.Rejected:
                    articles = articles.Where(c => c.IsActive == false);
                    break;
                case ArticleStatusEnum.Pendings:
                    articles = articles.Where(c => !c.IsActive.HasValue);
                    break;
            }

            if (!string.IsNullOrEmpty(filter.SearchText))
                articles = articles.Where(c => c.Name.ToLower().Contains(filter.SearchText.ToLower()));

            return articles;
        }
    }
}
