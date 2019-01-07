using MailProvider.Core.Models;
using System;

namespace MailProvider.Core
{
    public class MailSettings
    {
        public string FromName { get; set; }
        public string FromAddress { get; set; }
        public string LocalDomain { get; set; }
        public string MailServerAddress { get; set; }
        public int MailServerPort { get; set; }
        public string UserId { get; set; }
        public string UserPassword { get; set; }
        public RegisterEmail RegisterEmail { get; set; }
        public ResetPasswordEmail ResetPasswordEmail { get; set; }
    }
}
