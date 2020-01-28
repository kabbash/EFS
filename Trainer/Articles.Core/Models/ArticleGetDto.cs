using Attachments.Core.Models;
using System;
using System.Collections.Generic;

namespace Articles.Core.Models
{
    public class ArticleGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime? Date { get; set; }
        public string Place { get; set; }
        public bool IsActive { get; set; }
        public List<SliderItemDto> Images { get; set; }
        public int CategoryId { get; set; }
    }
}
