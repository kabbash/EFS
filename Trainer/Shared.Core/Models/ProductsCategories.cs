using Shared.Core.Models.Base;
using Shared.Core.Utilities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Core.Models
{
    public partial class ProductsCategories : IBaseModel,IDDLBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePicture { get; set; }
        public int? ParentId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        [ForeignKey("ParentId")]
        public virtual ICollection<ProductsCategories> Subcategories { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
