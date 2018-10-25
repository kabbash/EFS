using System;
using System.Collections.Generic;

namespace Shared.Core.Models
{
    public partial class ClientsImages
    {
        public short Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string ClientId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public Clients Client { get; set; }
    }
}
