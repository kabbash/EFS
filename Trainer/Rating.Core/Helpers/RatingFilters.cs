using Rating.Core.Models;
using Shared.Core.Models;
using System.Linq;

namespace Rating.Core.Helpers
{
    public static class RatingFilters
    {
        public static IQueryable<EntityRating> OldRate(this IQueryable<EntityRating> ratings, RatingDto ratingDto)
        {
            return ratings.Where(c => c.EntityId == ratingDto.EntityId && c.CreatedBy == ratingDto.CurrentUserId && c.EntityTypeId == ratingDto.EntityTypeId);
        }

        public static IQueryable<EntityRating> AllRates(this IQueryable<EntityRating> ratings, RatingDto ratingDto)
        {
            return ratings.Where(c => c.EntityId == ratingDto.EntityId && c.EntityTypeId == ratingDto.EntityTypeId);
        }
    }
}
