using System;
using System.Collections.Generic;

namespace Trainer.EF.Models
{
    public partial class Measurments
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public byte TypeId { get; set; }
    }
}
