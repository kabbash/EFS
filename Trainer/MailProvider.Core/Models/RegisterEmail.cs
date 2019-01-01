using System;
using System.Collections.Generic;
using System.Text;

namespace MailProvider.Core.Models
{
    public class RegisterEmail
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string VerifyEmailUrl { get; set; }
    }
}
