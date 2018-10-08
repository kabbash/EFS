using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Models
{
    public class AddRoleToUserDto
    {
        public string Username { get; set; }
        public string RoleName { get; set; }
    }
}
