using System;
using System.Collections.Generic;

namespace Trainer.EF.Models
{
    public partial class ProductsCategories
    {
        public ProductsCategories()
        {
            ProductsSubcategories = new HashSet<ProductsSubcategories>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public string ProfilePicture { get; set; }

        public ICollection<ProductsSubcategories> ProductsSubcategories { get; set; }
    }
}
