using Shared.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Core.Models
{
    public partial class ClientsImages 
    {
        public int Id { get; set; }
        [Required]
        public string Path { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string ClientId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual Clients Client { get; set; }
    }
}
