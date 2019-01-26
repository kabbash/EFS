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

            switch (filter.Status)
            {
                case ProductStatusEnum.All:
                    break;
                case ProductStatusEnum.Active:
                    products = products.Where(c => c.IsActive.HasValue && c.IsActive.Value);
                    break;
                case ProductStatusEnum.Pending:
                    products = products.Where(c => !c.IsActive.HasValue);
                    break;
                case ProductStatusEnum.Rejected:
                    products = products.Where(c => c.IsActive.HasValue && !c.IsActive.Value);
                    break;
                default:
                    break;
            }

            if (filter.IsSpecial.HasValue)
                products = products.Where(c => c.IsActive == filter.IsSpecial);

            if (!string.IsNullOrEmpty(filter.SearchText))
                products = products.Where(p => p.Name.ToLower().Contains(filter.SearchText.ToLower()));

            return products;
        }
    }
}
