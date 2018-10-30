using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lookups.Core.Interfaces
{
    public interface ILookupService<DTO, E>
    {
        ResultMessage GetAll();
        ResultMessage Insert(DTO lookupDto);
        ResultMessage GetById(int id);
        ResultMessage Update(DTO lookupDto, int id);
        ResultMessage Delete(int id);
    }
}
