using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Products.Core.Models
{
    public class ProductsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? ExpDate { get; set; }
        public DateTime? ProdDate { get; set; }
        public decimal Price { get; set; }
        public string ProfilePicture { get; set; }
        public IFormFile ProfilePictureFile { get; set; }
        public IList<IFormFile> ProductsImagesFiles { get; set; }
        public string[] ProductsImages { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public decimal Rate { get; set; }
        public SellerInfo Seller { get; set; }
    }
}
