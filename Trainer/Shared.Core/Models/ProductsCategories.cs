using System;
using System.Collections.Generic;

namespace Shared.Core.Models
{
    public partial class ProductsCategories
    {
        public ProductsCategories()
        {
            ProductsSubcategories = new HashSet<ProductsSubcategories>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePicture { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<ProductsSubcategories> ProductsSubcategories { get; set; }
    }
}
