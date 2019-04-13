using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public bool EmailConfirmed { get; set; }
        public List<string> Roles { get; internal set; }
        public bool IsBlocked { get; set; }
        public string PhoneNumber { get; set; }
    }
}
