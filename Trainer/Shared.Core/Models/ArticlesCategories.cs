using System;
using System.Collections.Generic;

namespace Shared.Core.Models
{
    public partial class ArticlesCategories
    {
        public ArticlesCategories()
        {
            Articles = new HashSet<Articles>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public string ProfilePicture { get; set; }

        public ICollection<Articles> Articles { get; set; }
    }
}
