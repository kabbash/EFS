using Shared.Core.Utilities;

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
