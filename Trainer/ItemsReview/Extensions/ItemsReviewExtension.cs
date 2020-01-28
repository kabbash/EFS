using ItemsReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBModels = Shared.Core.Models;

namespace ItemsReview.Extensions
{
    public static class ItemsReviewExtension
    {
        public static IQueryable<DBModels.ItemsForReview> ApplyFilter(this IQueryable<DBModels.ItemsForReview> itemsForReview, ItemsReviewFilter filter)
        {
            if (filter == null)
                return itemsForReview;

            if (!string.IsNullOrEmpty(filter.SearchText))
                itemsForReview = itemsForReview.Where(c => c.Name.ToLower().Contains(filter.SearchText.ToLower()));

            return itemsForReview;
        }
    }
}
