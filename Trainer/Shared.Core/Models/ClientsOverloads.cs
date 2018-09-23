using System;
using System.Collections.Generic;

namespace Shared.Core.Models
{
    public partial class ClientsOverloads
    {
        public int Id { get; set; }
        public byte TypeId { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public string ClientId { get; set; }

        public Clients Client { get; set; }
    }
}
