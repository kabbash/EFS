using Products.Core.Models;
using System.Linq;

namespace Products.Core.Extensions
{
    public static class ProductsExtensions
    {
        public static IQueryable<Shared.Core.Models.Products> ApplyFilter(this IQueryable<Shared.Core.Models.Products> products, ProductFilter filter)
        {
            if (filter == null)
                return products;

            if (filter.IsActive.HasValue)
                products = products.Where(c => c.IsActive == filter.IsActive);
            if (filter.IsSpecial.HasValue)
                products = products.Where(c => c.IsActive == filter.IsSpecial);
            return products;
        }
    }
}
