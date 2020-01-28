using Shared.Core.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lookups.Core.Interfaces
{
    public interface ICommonService
    {
        ResultMessage GetEntityDDL(int entityTypeId);
    }
}
