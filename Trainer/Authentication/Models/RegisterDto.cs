﻿using Authentication.Enums;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Models
{
    public class RegisterDto
    {
        public string FullName { get; set; }        
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //[AdaptMember("PasswordHash")]
        public string Password { get; set; }
        [AdaptIgnore]
        public UserEnum Type { get; set; }
    }
}
