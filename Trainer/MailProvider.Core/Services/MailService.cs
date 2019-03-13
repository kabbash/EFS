using MailProvider.Core.Interfaces;
using MailProvider.Core.Resources;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using Shared.Core.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Shared.Core.Utilities.Extensions;
using Shared.Core.Utilities.Models;

namespace MailProvider.Core.Services
{
    public class MailService: IEmailService
    {
        private readonly MailSettings _settings;
        private readonly EmailTemplatesPathsResources _tempaltesUrls;
        private readonly IHostingEnvironment _hostingEnvironment;

        public MailService(IOptions<MailSettings> settings, IOptions<EmailTemplatesPathsResources> templatesUrlsResources, IHostingEnvironment environment)
        {
            _settings = settings.Value;
            _hostingEnvironment = environment;
            _tempaltesUrls = templatesUrlsResources.Value;
        }

        public async Task SendEmailAsync(string email, string subject, EmailTemplatesEnum emailTemplate, Dictionary<string,string> replacements)
        {
            try
            {

                var emailBody = GetTemplateByType(emailTemplate).ApplyReplacements(replacements).Replace(EmailPlaceHolders.BaseURL, _settings.IconsBaseURL);
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
                    Body = emailBody,
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

        private string GetTemplateByType(EmailTemplatesEnum emailTemplate)
        {
            var templateRelativePath = string.Empty;
            var placeHolders = new Dictionary<string, string>();

            switch (emailTemplate)
            {
                case EmailTemplatesEnum.Register:
                    templateRelativePath = _tempaltesUrls.Register;
                    break;
                case EmailTemplatesEnum.ResetPassword:
                    templateRelativePath = _tempaltesUrls.ResetPassword;
                    break;
                case EmailTemplatesEnum.ContactUs:
                    templateRelativePath = _tempaltesUrls.ContactUs;
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
    }
}
