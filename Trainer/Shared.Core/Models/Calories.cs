using System;
using System.Collections.Generic;

namespace Shared.Core.Models
{
    public partial class Calories
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
    }
}
