using Neutrints.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neutrints.Core.Extensions
{
    public static class FoodItemsExtensions
    {
        public static IQueryable<Shared.Core.Models.FoodItem> ApplyFilter(this IQueryable<Shared.Core.Models.FoodItem> foodItems, FoodIemFilter filter)
        {
            if (filter == null)
                return foodItems;

            if (!string.IsNullOrEmpty(filter.SearchText))
                foodItems = foodItems.Where(p => p.Name.ToLower().Contains(filter.SearchText.ToLower()));

            return foodItems;
        }
    }
}
