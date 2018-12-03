using Shared.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Core.Models
{
    public partial class ProgramsImages : IImageBase
    {
        public int Id { get; set; }
        [Required]
        public string Path { get; set; }
        public int ProgramId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public virtual TrainersPrograms Program { get; set; }
    }
}
