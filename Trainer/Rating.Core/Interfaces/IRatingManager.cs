using Rating.Core.Models;
using Shared.Core.Models.Base;
using Shared.Core.Utilities.Models;

namespace Rating.Core.Interfaces
{
    public interface IRatingManager<TEntity>  where TEntity : IRateBase
    {
        ResultMessage AddOrUpdate(RatingDto entityRating);
    }
}
