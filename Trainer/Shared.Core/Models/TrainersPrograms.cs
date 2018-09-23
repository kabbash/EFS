using System;
using System.Collections.Generic;

namespace Shared.Core.Models
{
    public partial class TrainersPrograms
    {
        public TrainersPrograms()
        {
            ProgramsImages = new HashSet<ProgramsImages>();
            ProgramsPrices = new HashSet<ProgramsPrices>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TrainerId { get; set; }
        public string ProfilePicture { get; set; }

        public Trainers Trainer { get; set; }
        public ICollection<ProgramsImages> ProgramsImages { get; set; }
        public ICollection<ProgramsPrices> ProgramsPrices { get; set; }
    }
}
