using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Models
{
    public class UserAccessDto
    {
        public string Username { get; set; }
        public bool Blocked { get; set; }
    }
}
