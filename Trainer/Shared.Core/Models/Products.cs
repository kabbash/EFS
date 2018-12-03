using Shared.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Core.Models
{
    public partial class Products : IRateBase,IBaseModel
    {
        public Products()
        {
            ProductsImages = new HashSet<ProductsImages>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? ExpDate { get; set; }
        public DateTime? ProdDate { get; set; }
        public decimal Price { get; set; }
        public string ProfilePicture { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Rate { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ProductsCategories Category { get; set; }
        public virtual ICollection<ProductsImages> ProductsImages { get; set; }
    }
}
