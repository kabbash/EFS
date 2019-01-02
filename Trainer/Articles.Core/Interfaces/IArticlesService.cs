using Articles.Core.Models;
using Shared.Core.Utilities.Models;

namespace Articles.Core.Interfaces
{
    public interface IArticlesService
    {
        ResultMessage GetAll(int pageNo, int pageSize , ArticlesFilter filter=null);
        ResultMessage GetByCategoryId(int id);
        ResultMessage GetByPredefinedCategoryKey(int id);        
        ResultMessage Insert(ArticleAddDto product, string userId);
        ResultMessage GetById(int id);
        ResultMessage Update(ArticleAddDto product, int id, string userId);
        ResultMessage Delete(int id);
        ResultMessage Approve(int id);
        ResultMessage GetPendingApprovalItems(ArticlesFilter filter = null);
    }
}
