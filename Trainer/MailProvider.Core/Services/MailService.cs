using MailProvider.Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using Shared.Core.Settings;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Extensions;
using Shared.Core.Utilities.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MailProvider.Core.Services
{
    public class MailService : IEmailService
    {
        private readonly AppSettings _settings;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ILogger<MailService> _logger;

        public MailService(IOptions<AppSettings> settings, IHostingEnvironment environment, ILogger<MailService> logger)
        {
            _settings = settings.Value;
            _hostingEnvironment = environment;
            _logger = logger;
        }

        public async Task SendEmailAsync(string email, string subject, EmailTemplatesEnum emailTemplate, Dictionary<string, string> replacements)
        {
            try
            {
                replacements = SetCommonReplacements(replacements);
                var emailBody = GetTemplateByType(emailTemplate).ApplyReplacements(replacements);
                var smtpClient = new SmtpClient
                {
                    Host = _settings.EmailSettings.MailServerAddress, // set your SMTP server name here
                    Port = _settings.EmailSettings.MailServerPort, // Port 
                    EnableSsl = false,
                    Credentials = new NetworkCredential(_settings.EmailSettings.UserId, _settings.EmailSettings.UserPassword),
                };

                using (var mailMessage = new MailMessage(_settings.EmailSettings.FromAddress, email)
                {
                    Subject = subject,
                    Body = emailBody,
                    IsBodyHtml = true
                })
                {
                    mailMessage.To.Add(_settings.EmailSettings.FromAddress);
                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
            }
        }
        private string GetTemplateByType(EmailTemplatesEnum emailTemplate)
        {
            var templateRelativePath = string.Empty;
            var placeHolders = new Dictionary<string, string>();

            switch (emailTemplate)
            {
                case EmailTemplatesEnum.Register:
                    templateRelativePath = _settings.AppPathsSettings.EmailTemplates.Register;
                    break;
                case EmailTemplatesEnum.ResetPassword:
                    templateRelativePath = _settings.AppPathsSettings.EmailTemplates.ResetPassword;
                    break;
                case EmailTemplatesEnum.ContactUs:
                    templateRelativePath = _settings.AppPathsSettings.EmailTemplates.ContactUs;
                    break;
            }
            var templatePath = _hostingEnvironment.WebRootPath + Path.DirectorySeparatorChar.ToString() + templateRelativePath;
            var builder = new BodyBuilder();
            using (StreamReader SourceReader = File.OpenText(templatePath))
            {
                builder.HtmlBody = SourceReader.ReadToEnd();
            }
            return builder.HtmlBody;
        }
        private Dictionary<string, string> SetCommonReplacements(Dictionary<string, string> replacements)
        {
            replacements.Add(EmailPlaceHolders.AdminFBurl, _settings.EmailSettings.AdminFBurl);
            replacements.Add(EmailPlaceHolders.AdminTWurl, _settings.EmailSettings.AdminTWurl);
            replacements.Add(EmailPlaceHolders.AdminPhoneNumber, _settings.EmailSettings.AdminPhoneNumber);
            replacements.Add(EmailPlaceHolders.AdminWhatsAppNo, _settings.EmailSettings.AdminWhatsAppNo);
            replacements.Add(EmailPlaceHolders.IconsBaseURL, _settings.AppUrlsSettings.BEApplicationBase);
            return replacements;
        }
    }
}
