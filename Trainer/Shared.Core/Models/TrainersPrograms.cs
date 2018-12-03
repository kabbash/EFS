using Shared.Core.Models.Base;
using System;
using System.Collections.Generic;

namespace Shared.Core.Models
{
    public partial class TrainersPrograms : IBaseModel
    {
        public TrainersPrograms()
        {
            ProgramsImages = new HashSet<ProgramsImages>();
            ProgramsPrices = new HashSet<ProgramsPrices>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TrainerId { get; set; }
        public string ProfilePicture { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Trainers Trainer { get; set; }
        public virtual ICollection<ProgramsImages> ProgramsImages { get; set; }
        public virtual ICollection<ProgramsPrices> ProgramsPrices { get; set; }
    }
}
