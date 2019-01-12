using Articles.Core.Models;
using Shared.Core.Utilities.Models;

namespace Articles.Core.Interfaces
{
    public interface IArticlesService
    {
        ResultMessage GetAll(int pageNo, int pageSize, ArticlesFilter filter = null);
        ResultMessage GetByCategoryId(int id, int pageNo, int pageSize);
        ResultMessage GetByPredefinedCategoryKey(int id, int pageNo, int pageSize);
        ResultMessage Insert(ArticleAddDto product);
        ResultMessage GetById(int id);
        ResultMessage Update(ArticleAddDto product, int id);
        ResultMessage Delete(int id);
        ResultMessage Approve(int id);
        ResultMessage Reject(RejectDto rejectDto);
        ResultMessage GetPendingApprovalItems(ArticlesFilter filter = null);
        ResultMessage GetFilteredData(ArticlesFilter filter);
    }
}
