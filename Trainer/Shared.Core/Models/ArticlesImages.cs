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
        public string Text { get; set; }
        public int ArticleId { get; set; }

        public virtual Articles Article { get; set; }
    }
}
