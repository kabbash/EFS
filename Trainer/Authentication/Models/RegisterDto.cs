using Authentication.Enums;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Models
{
    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //[AdaptMember("PasswordHash")]
        public string Password { get; set; }
        [AdaptIgnore]
        public UserEnum Type { get; set; }
    }
}
