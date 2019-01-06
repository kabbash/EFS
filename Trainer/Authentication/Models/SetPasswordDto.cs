using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Models
{
    public class SetPasswordDto
    {
        public string ActivationToken { get; set; }
        public string NewPassword { get; set; }
    }
}
