using Shared.Core.Models.Base;
using System;
using System.Collections.Generic;

namespace Shared.Core.Models
{
    public partial class Calories : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
