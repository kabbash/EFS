using System;
using System.Collections.Generic;

namespace Trainer.Models
{
    public partial class ClientsMeasurments
    {
        public int Id { get; set; }
        public byte TypeId { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public string ClientId { get; set; }

        public Clients Client { get; set; }
    }
}
