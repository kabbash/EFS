using System;
using System.Collections.Generic;
using System.Text;

namespace MailProvider.Core.Models
{
    public class ResetPasswordEmail
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string ResetPasswordUrl { get; set; }
    }
}
