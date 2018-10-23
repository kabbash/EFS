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
        public string Subject { get; set; }
        public string Body { get; set; }
        public string VerifyEmailUrl { get; set; }

    }
}
