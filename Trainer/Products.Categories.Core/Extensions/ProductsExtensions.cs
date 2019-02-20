using Products.Core.Models;
using Shared.Core.Utilities.Enums;
using System.Linq;
using DBModels = Shared.Core.Models;

namespace Products.Core.Extensions
{
    public static class ProductsExtensions
    {
        public static IQueryable<DBModels.Products> ApplyFilter(this IQueryable<DBModels.Products> products, ProductFilter filter)
        {
            if (filter == null)
                return products;

            if (filter.Status != StatusFilterEnum.All)
                switch (filter.Status)
                {
                    case StatusFilterEnum.Pending:
                        products = products.Where(c => !c.IsActive.HasValue);
                        break;
                    case StatusFilterEnum.Rejected:
                        products = products.Where(c => c.IsActive.HasValue && !c.IsActive.Value);
                        break;
                    default:
                        products = products.Where(c => c.IsActive.HasValue && c.IsActive.Value);
                        break;
                }

            if (filter.CategoryId != 0)
                products = products.Where(c => c.CategoryId == filter.CategoryId);

            if (filter.IsSpecial.HasValue)
                products = products.Where(c => c.IsSpecial == filter.IsSpecial);

            if (!string.IsNullOrEmpty(filter.SearchText))
                products = products.Where(p => p.Name.ToLower().Contains(filter.SearchText.ToLower()));

            return products;
        }
    }
}
