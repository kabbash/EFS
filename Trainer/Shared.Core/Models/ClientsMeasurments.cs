using System;
using System.Collections.Generic;

namespace Shared.Core.Models
{
    public partial class ClientsMeasurments
    {
        public int Id { get; set; }
        public byte TypeId { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public string ClientId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Clients Client { get; set; }
    }
}
