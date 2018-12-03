using Shared.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Models
{
    public class EntityRating : IBaseModel
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public int EntityTypeId { get; set; }
        public virtual EntityTypes EntityType { get; set; }
    }
}
