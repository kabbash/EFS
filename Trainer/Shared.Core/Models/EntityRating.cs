using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Models
{
    public class EntityRating
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int EntityTypeId { get; set; }

        public EntityTypes EntityType { get; set; }
    }
}
