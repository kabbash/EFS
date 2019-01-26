using Shared.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Core.Models
{
    public partial class ProductsImages :IImageBase
    {
        public int Id { get; set; }
        public string Path { get; set; }
        [ForeignKey("Product")]
        public int ParentId { get; set; }
        public virtual Products Product { get; set; }
    }
}
