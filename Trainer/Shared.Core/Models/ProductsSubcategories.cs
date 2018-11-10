using System;
using System.Collections.Generic;

namespace Shared.Core.Models
{
    public partial class ProductsSubcategories
    {
        public ProductsSubcategories()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public ProductsCategories Category { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
