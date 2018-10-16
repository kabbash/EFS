using System;
using System.Collections.Generic;

namespace Trainer.EF.Models
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
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }

        public Clients Client { get; set; }
    }
}
