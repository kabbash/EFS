using System;
using System.Collections.Generic;

namespace Trainer.Models
{
    public partial class ProgramsImages
    {
        public short Id { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public byte ProgramId { get; set; }
        public string Name { get; set; }

        public TrainersPrograms Program { get; set; }
    }
}
