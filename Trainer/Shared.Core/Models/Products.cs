using Shared.Core.Models.Base;
using Shared.Core.Utilities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Core.Models
{
    public partial class Products : IRateBase, IBaseModel, IDDLBase
    {
        public Products()
        {
            ProductsImages = new HashSet<ProductsImages>();
            IsActive = false;
            IsSpecial = false;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SubFolderName { get; set; }
        public DateTime? ExpDate { get; set; }        
        public decimal Price { get; set; }
        public string ProfilePicture { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Rate { get; set; }
        public bool IsSpecial { get; set; }
        public string RejectReason { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ProductsCategories Category { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual AspNetUsers Seller { get; set; }

        public virtual ICollection<ProductsImages> ProductsImages { get; set; }
    }
}
