using Articles.Core.Models;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.Core.Interfaces
{
    public interface IArticlesService
    {
        ResultMessage GetAll();
        ResultMessage Insert(ArticleAddDto product, string userId);
        ResultMessage GetById(int id);
        ResultMessage Update(ArticleAddDto product, int id, string userId);
        ResultMessage Delete(int id);
    }
}
