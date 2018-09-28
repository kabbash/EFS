using System;
using System.Collections.Generic;

namespace Shared.Core.Models
{
    public partial class ProductsImages
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int ProductId { get; set; }

        public Products Product { get; set; }
    }
}
