using Microsoft.AspNetCore.Http;
using System;

namespace Articles.Core.Models
{
    public class ArticlesCategoriesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePicture { get; set; }
        public IFormFile ProfilePictureFile { get; set; }
        public int? PredefinedKey { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime? UpdatedAt { get; set; }
        //public string CreatedBy { get; set; }
        //public string UpdatedBy { get; set; }
    }
}
