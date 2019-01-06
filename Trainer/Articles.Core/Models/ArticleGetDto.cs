using System.Collections.Generic;

namespace Articles.Core.Models
{
    public class ArticleGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProfilePicture { get; set; }
        public bool IsActive { get; set; }
        public List<ImageWithTextDto> Images { get; set; }
    }
}
