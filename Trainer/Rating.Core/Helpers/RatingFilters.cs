﻿using Rating.Core.Models;
using Shared.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rating.Core.Helpers
{
    public static class RatingFilters
    {
        public static IQueryable<EntityRating> OldRate(this IQueryable<EntityRating> ratings, RatingDto ratingDto)
        {
            return ratings.Where(c => c.EntityId == ratingDto.EntityId && c.CreatedBy == ratingDto.CreatedBy && c.EntityTypeId == ratingDto.EntityTypeId);
        }

        public static IQueryable<EntityRating> AllRates(this IQueryable<EntityRating> ratings, RatingDto ratingDto)
        {
            return ratings.Where(c => c.EntityId == ratingDto.EntityId && c.EntityTypeId == ratingDto.EntityTypeId);
        }
    }
}