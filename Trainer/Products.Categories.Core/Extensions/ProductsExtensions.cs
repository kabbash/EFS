using Products.Core.Models;
using Shared.Core.Utilities.Enums;
using System.Linq;

namespace Products.Core.Extensions
{
    public static class ProductsExtensions
    {
        public static IQueryable<Shared.Core.Models.Products> ApplyFilter(this IQueryable<Shared.Core.Models.Products> products, ProductFilter filter)
        {
            if (filter == null)
                return products;

            switch (filter.Status)
            {
                case StatusFilterEnum.All:
                    break;
                case StatusFilterEnum.Active:
                    products = products.Where(c => c.IsActive.HasValue && c.IsActive.Value);
                    break;
                case StatusFilterEnum.Pending:
                    products = products.Where(c => !c.IsActive.HasValue);
                    break;
                case StatusFilterEnum.Rejected:
                    products = products.Where(c => c.IsActive.HasValue && !c.IsActive.Value);
                    break;
                default:
                    break;
            }

            if(filter.CategoryId != 0)
                products = products.Where(c => c.CategoryId == filter.CategoryId);

            if (filter.IsSpecial.HasValue)
                products = products.Where(c => c.IsActive == filter.IsSpecial);

            if (!string.IsNullOrEmpty(filter.SearchText))
                products = products.Where(p => p.Name.ToLower().Contains(filter.SearchText.ToLower()));

            return products;
        }
    }
}
