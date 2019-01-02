using Shared.Core.Models.Base;
using System;
using System.Collections.Generic;

namespace Shared.Core.Models
{
    public partial class ArticlesCategories : IBaseModel
    {
        public ArticlesCategories()
        {
            Articles = new HashSet<Articles>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? PredefinedKey { get; set; }

        public virtual ICollection<Articles> Articles { get; set; }
    }
}
