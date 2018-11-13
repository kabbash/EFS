using Rating.Core.Models;
using Shared.Core.Models;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rating.Core.Interfaces
{
    public interface IRatingManager<TEntity>  where TEntity : RateBase
    {
        ResultMessage AddOrUpdate(RatingDto entityRating);
    }
}
