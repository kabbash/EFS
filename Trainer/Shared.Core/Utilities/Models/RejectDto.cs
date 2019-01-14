using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Utilities.Models
{
    public class RejectDto : IUserDto
    {
        public int Id { get; set; }
        public string RejectReason { get; set; }
        public string UserId { get; set; }
    }
}
