using System;
using System.Collections.Generic;

namespace Shared.Core.Models
{
    public partial class Articles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string ProfilePicture { get; set; }
        public string AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public AspNetUsers Author { get; set; }
        public ArticlesCategories Category { get; set; }
    }
}
