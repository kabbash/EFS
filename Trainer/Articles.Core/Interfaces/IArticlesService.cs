using Articles.Core.Models;
using Shared.Core.Utilities;

namespace Articles.Core.Interfaces
{
    public interface IArticlesService
    {
        ResultMessage GetAll();
        ResultMessage GetByCategoryId(int id);
        ResultMessage Insert(ArticleAddDto product, string userId);
        ResultMessage GetById(int id);
        ResultMessage Update(ArticleAddDto product, int id, string userId);
        ResultMessage Delete(int id);
    }
}
