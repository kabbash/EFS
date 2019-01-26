using Shared.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shared.Core.Models
{
    public class ArticlesImages : IImageBase
    {
        public int Id { get; set; }
        [Required]
        public string Path { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [ForeignKey("Article")]
        public int ParentId { get; set; }

        public virtual Articles Article { get; set; }
    }
}
