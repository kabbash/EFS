using MailProvider.Core.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailProvider.Core.Services
{
    public class MailService: IEmailService
    {
        private readonly MailSettings _settings;
        public MailService(IOptions<MailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var smtpClient = new SmtpClient
                {
                    Host = _settings.MailServerAddress, // set your SMTP server name here
                    Port = _settings.MailServerPort, // Port 
                    EnableSsl = true,
                    Credentials = new NetworkCredential(_settings.UserId, _settings.UserPassword),
                    
                };

                using (var mailMessage = new MailMessage(_settings.FromAddress, email)
                {
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true
                })
                {
                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {

                
            }
            
        }
    }
}
