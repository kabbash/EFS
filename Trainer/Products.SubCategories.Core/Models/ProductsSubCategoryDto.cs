using System;
using System.Collections.Generic;
using System.Text;

namespace Products.SubCategories.Core.Models
{
    public class ProductsSubCategoryDto
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public string ProfilePicture { get; set; }
        public byte CategoryId { get; set; }
    }
}
