using System;
using System.Collections.Generic;

namespace Trainer.Models
{
    public partial class ProductsOwners
    {
        public ProductsOwners()
        {
            Products = new HashSet<Products>();
        }

        public string Id { get; set; }
        public string ContactInfo { get; set; }

        public AspNetUsers AspNetUsers { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
