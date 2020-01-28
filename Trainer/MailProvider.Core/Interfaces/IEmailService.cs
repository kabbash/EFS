using Shared.Core.Utilities.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MailProvider.Core.Interfaces
{
    public interface IEmailService
    {
         Task SendEmailAsync(string email, string subject, EmailTemplatesEnum emailTemplate, Dictionary<string,string> replacements);
    }
}
