using Microsoft.AspNetCore.Http;

namespace Products.Core.Models
{
    public class ProductsCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile ProfilePictureFile { get; set; }
        public string ProfilePicture { get; set; }
        public int? ParentId { get; set; }
        public bool HasSubCategory { get; set; }
    }
}
