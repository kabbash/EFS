using System;
using System.Collections.Generic;

namespace Shared.Core.Models
{
    public partial class ProgramsPrices
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Duration { get; set; }
        public int ProgramId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TrainersPrograms Program { get; set; }
    }
}
