using Shared.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Core.Models
{
    public class Banner : IBaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get ; set ; }
        public string CreatedBy { get  ; set; }
        public DateTime? UpdatedAt { get  ; set  ; }
        public string UpdatedBy { get  ; set  ; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public string Title { get; set; }
        public string ButtonUrl { get; set; }
        public string ButtonText { get; set; }
    }
}
