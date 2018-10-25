using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Core.Models
{
    public class ProductsSubCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePicture { get; set; }
        public byte CategoryId { get; set; }
    }
}
