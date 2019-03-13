using FluentValidation;
using Home.Core.Interfaces;
using Home.Core.Models;
using MailProvider.Core;
using MailProvider.Core.Interfaces;
using Microsoft.Extensions.Options;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Extensions;
using Shared.Core.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace Home.Core.Services
{
    public class HomeService : IHomeService
    {
        private readonly IValidator<ContactUsDto> _validator;
        private readonly IEmailService _emailService;
        private readonly MailSettings _emailSettings;

        public HomeService(IValidator<ContactUsDto> validator,
            IEmailService emailService,
            IOptions<MailSettings> mailSettings)
        {
            _validator = validator;
            _emailService = emailService;
            _emailSettings = mailSettings.Value;
        }

        public ResultMessage ContactUs(ContactUsDto contactUsDto)
        {
            var validationResult = _validator.Validate(contactUsDto);
            if (!validationResult.IsValid)
                return new ResultMessage
                {
                    Status = HttpStatusCode.BadRequest,
                    ValidationMessages = validationResult.GetErrorsList()
                };

            try
            {
                var replacements = SetContactUsMailReplacements(contactUsDto.Name, contactUsDto.Email, contactUsDto.PhoneNumber,contactUsDto.Details);
                _emailService.SendEmailAsync(_emailSettings.AdminMail, _emailSettings.ContactUsEmail.Subject, EmailTemplatesEnum.ContactUs , replacements);
                return new ResultMessage
                {
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ResultMessage()
                {
                    ErrorCode = (int)HomeErrorsCodeEnum.ContactUs,
                    exception = ex,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }


        private Dictionary<string, string> SetContactUsMailReplacements(string fullName, string email,string phone, string details)
        {
            var replacements = new Dictionary<string, string>();
            replacements.Add(EmailPlaceHolders.UserName, fullName);
            replacements.Add(EmailPlaceHolders.UserEmail, email);
            replacements.Add(EmailPlaceHolders.PhoneNumber, phone);
            replacements.Add(EmailPlaceHolders.ContactUsDetails, details);
            return replacements;
        }

    }
}
