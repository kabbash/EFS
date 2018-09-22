using System;
using System.Collections.Generic;

namespace Trainer.Models
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

        public AspNetUsers AspNetUsers { get; set; }
        public ICollection<ClientsDocuments> ClientsDocuments { get; set; }
        public ICollection<ClientsImages> ClientsImages { get; set; }
        public ICollection<ClientsMeasurments> ClientsMeasurments { get; set; }
        public ICollection<ClientsOverloads> ClientsOverloads { get; set; }
    }
}
