using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Articles.Core.Models
{
    public class ArticleAddDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string ProfilePicture { get; set; }
        public IFormFile ProfilePictureFile { get; set; }
        public IList<IFormFile> ImagesLstFiles { get; set; }
    }
}
