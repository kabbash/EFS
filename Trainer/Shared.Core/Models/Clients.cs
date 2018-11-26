using System;
using System.Collections.Generic;

namespace Shared.Core.Models
{
    public partial class Clients
    {
        public Clients()
        {
            ClientsDocuments = new HashSet<ClientsDocuments>();
            ClientsImages = new HashSet<ClientsImages>();
            ClientsMeasurments = new HashSet<ClientsMeasurments>();
            ClientsOverloads = new HashSet<ClientsOverloads>();
        }

        public string Id { get; set; }

        public virtual AspNetUsers IdNavigation { get; set; }
        public virtual ICollection<ClientsDocuments> ClientsDocuments { get; set; }
        public virtual ICollection<ClientsImages> ClientsImages { get; set; }
        public virtual ICollection<ClientsMeasurments> ClientsMeasurments { get; set; }
        public virtual ICollection<ClientsOverloads> ClientsOverloads { get; set; }
    }
}
