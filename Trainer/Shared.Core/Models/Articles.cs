﻿using Shared.Core.Models.Base;
using Shared.Core.Utilities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Core.Models
{
    public partial class Articles : IBaseModel,IDDLBase
    {
        public Articles()
        {
            IsActive = false;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTime? Date { get; set; }
        public int CategoryId { get; set; }
        public string ProfilePicture { get; set; }
        public string SubFolderName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public string RejectReason { get; set; }
        public bool IsDraft { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual AspNetUsers Author { get; set; }
        public virtual ArticlesCategories Category { get; set; }
        public virtual List<ArticlesImages> Images { get; set; }
    }
}
