using System;
using System.Collections.Generic;

namespace Trainer.EF.Models
{
    public partial class Trainers
    {
        public Trainers()
        {
            TrainersPrograms = new HashSet<TrainersPrograms>();
        }

        public string Id { get; set; }
        public string Bio { get; set; }

        public AspNetUsers IdNavigation { get; set; }
        public ICollection<TrainersPrograms> TrainersPrograms { get; set; }
    }
}
