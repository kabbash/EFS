using Articles.Core.Models;
using Shared.Core.Utilities.Models;

namespace Articles.Core.Interfaces
{
    public interface IArticlesService
    {
        ResultMessage GetAll(ArticlesFilter filter);
        ResultMessage GetById(int id);
        ResultMessage Insert(ArticleAddDto product);        
        ResultMessage Update(ArticleAddDto product, int id);
        ResultMessage Delete(int id);
        ResultMessage Approve(int id);
        ResultMessage Reject(RejectDto rejectDto);                
    }
}
