using System;
using System.Collections.Generic;

namespace Trainer.EF.Models
{
    public partial class ProductsSubcategories
    {
        public ProductsSubcategories()
        {
            Products = new HashSet<Products>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public byte CategoryId { get; set; }
        public string ProfilePicture { get; set; }

        public ProductsCategories Category { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
