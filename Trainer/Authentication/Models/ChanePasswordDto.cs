using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Models
{
   public class ChanePasswordDto
    {
        public string UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
