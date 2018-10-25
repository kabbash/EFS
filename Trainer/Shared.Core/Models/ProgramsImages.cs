using System;
using System.Collections.Generic;

namespace Shared.Core.Models
{
    public partial class ProgramsImages
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public int ProgramId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public TrainersPrograms Program { get; set; }
    }
}
