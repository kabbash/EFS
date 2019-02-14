using Banner.Core.Models;
using Shared.Core.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banner.Core.Interfaces
{
    public interface IBannerManager
    {
        ResultMessage Add(BannerDto Banner);
        ResultMessage Update(BannerDto Banner, int id);
        ResultMessage Delete(int id);
        ResultMessage Get(int pageNo, int pageSize);
        ResultMessage GetById(int id);
    }
}
