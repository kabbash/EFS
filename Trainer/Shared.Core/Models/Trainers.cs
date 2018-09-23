using System;
using System.Collections.Generic;

namespace Shared.Core.Models
{
    public partial class Trainers
    {
        public Trainers()
        {
            TrainersPrograms = new HashSet<TrainersPrograms>();
        }

        public string Id { get; set; }
        public string Bio { get; set; }

        public AspNetUsers AspNetUsers { get; set; }
        public ICollection<TrainersPrograms> TrainersPrograms { get; set; }
    }
}
