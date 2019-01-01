﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public bool EmailConfirmed { get; set; }
        public List<string> Roles { get; internal set; }
    }
}
