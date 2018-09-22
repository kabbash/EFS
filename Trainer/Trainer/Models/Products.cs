using System;
using System.Collections.Generic;

namespace Trainer.Models
{
    public partial class Products
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
        public string OwnerId { get; set; }
        public string ProfilePicture { get; set; }
        public byte SubcategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsActive { get; set; }

        public ProductsOwners Owner { get; set; }
        public ProductsSubcategories Subcategory { get; set; }
        public ICollection<ProductsImages> ProductsImages { get; set; }
    }
}
