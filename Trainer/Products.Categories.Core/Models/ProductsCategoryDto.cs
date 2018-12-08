using Microsoft.AspNetCore.Http;

namespace Products.Core.Models
{
    public class ProductsCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile profilePictureFile { get; set; }
        public string ProfilePicture { get; set; }
        public int? ParentId { get; set; }
    }
}
