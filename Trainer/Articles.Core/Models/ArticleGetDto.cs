using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.Core.Models
{
    public class ArticleGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProfilePicture { get; set; }
        public List<ImageWithTextDto> Images { get; set; }
    }
}
