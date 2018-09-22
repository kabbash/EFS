using System;
using System.Collections.Generic;

namespace Trainer.EF.Models
{
    public partial class Championships
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
    }
}
