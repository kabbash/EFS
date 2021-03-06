﻿namespace Shared.Core.Settings.Sub
{
    public class EmailSettings
    {
        public string IconsBaseURL { get; set; }
        public string AdminMail { get; set; }
        public string FromName { get; set; }
        public string FromAddress { get; set; }
        public string LocalDomain { get; set; }
        public string MailServerAddress { get; set; }
        public int MailServerPort { get; set; }
        public string UserId { get; set; }
        public string UserPassword { get; set; }
        public string AdminWhatsAppNo { get; set; }
        public string AdminPhoneNumber { get; set; }
        public string AdminFBurl { get; set; }
        public string AdminTWurl { get; set; }
        public RegisterEmail RegisterEmail { get; set; }
        public ResetPasswordEmail ResetPasswordEmail { get; set; }
        public ContactUsEmail ContactUsEmail { get; set; }
    }
}
