using FluentValidation;
using Home.Core.Interfaces;
using Home.Core.Models;
using MailProvider.Core.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shared.Core.Settings;
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
        private readonly AppSettings _settings;
        private readonly ILogger<HomeService> _logger;

        public HomeService(IValidator<ContactUsDto> validator,
            IEmailService emailService,
            IOptions<AppSettings> settings,
            ILogger<HomeService> logger)
        {
            _validator = validator;
            _emailService = emailService;
            _settings = settings.Value;
            _logger = logger;
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
                _emailService.SendEmailAsync(_settings.EmailSettings.AdminMail, _settings.EmailSettings.ContactUsEmail.Subject, EmailTemplatesEnum.ContactUs , replacements);
                return new ResultMessage
                {
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage()
                {
                    ErrorCode = (int)HomeErrorsCodeEnum.ContactUs,
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
