using Shared.Core.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lookups.Core.Interfaces
{
    public interface IDDLService<T> where T : IDDLBase
    {
        List<DDLDto> GetDDLItems(int entityEnum);
    }
}
