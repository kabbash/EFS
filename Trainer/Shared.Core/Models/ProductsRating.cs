using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Models
{
    public class ProductsRating
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public Products Product { get; set; }

    }
}
