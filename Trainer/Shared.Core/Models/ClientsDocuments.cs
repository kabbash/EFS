using System;
using System.Collections.Generic;

namespace Shared.Core.Models
{
    public partial class ClientsDocuments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string ClientId { get; set; }
        public bool SentToClient { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual Clients Client { get; set; }
    }
}
