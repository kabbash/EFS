using Articles.Core.Models;
using Shared.Core.Utilities.Models;

namespace Articles.Core.Interfaces
{
    public interface IArticlesService
    {
        ResultMessage GetAll(ArticlesFilter filter);
        ResultMessage GetById(int id);
        ResultMessage Insert(ArticleAddDto product, IUserDto user);
        ResultMessage Update(ArticleAddDto product, int id , IUserDto user);
        ResultMessage Delete(int id,IUserDto user);
        ResultMessage Approve(int id);
        ResultMessage Reject(RejectDto rejectDto, IUserDto user);
    }
}
