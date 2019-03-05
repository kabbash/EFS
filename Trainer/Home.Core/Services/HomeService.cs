using FluentValidation;
using Home.Core.Interfaces;
using Home.Core.Models;
using MailProvider.Core;
using MailProvider.Core.Interfaces;
using Microsoft.Extensions.Options;
using Shared.Core.Utilities.Models;
using System.Net;
using Shared.Core.Utilities.Extensions;
using System;
using Shared.Core.Utilities.Enums;

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
                var mailBody = _emailSettings.ContactUsEmail.Body.Replace("{0}", contactUsDto.Name).Replace("{1}", contactUsDto.Email).Replace("{2}", contactUsDto.PhoneNumber).Replace("{3}", contactUsDto.Details);
                _emailService.SendEmailAsync(_emailSettings.AdminMail, _emailSettings.ContactUsEmail.Subject, mailBody);
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
    }
}
