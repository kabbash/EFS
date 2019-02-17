using Rating.Core.Models;
using Shared.Core.Models.Base;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Models;
using System.Collections.Generic;

namespace Rating.Core.Interfaces
{
    public interface IRatingManager<TEntity>  where TEntity : IRateBase
    {
        ResultMessage AddOrUpdate(RatingDto entityRating);
        List<RatingDto> GetItemRatings(int entityId, RatingEntityTypesEnum ratingEntity);
    }
}
