using System;
using System.Collections.Generic;

namespace Trainer.Models
{
    public partial class ProgramsPrices
    {
        public byte Id { get; set; }
        public decimal Price { get; set; }
        public string Duration { get; set; }
        public byte ProgramId { get; set; }

        public TrainersPrograms Program { get; set; }
    }
}
