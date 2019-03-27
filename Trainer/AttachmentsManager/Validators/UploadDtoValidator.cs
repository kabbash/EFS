using Attachments.Core.Models;
using FluentValidation;

namespace Attachments.Core.Validators
{
    public class UploadFileDtoValidator : AbstractValidator<UploadFileDto>
    {
        //private readonly IOptions<AppSettings> _settings;
        public UploadFileDtoValidator() //IOptions<AppSettings> settings
        {
            //_settings = settings;
            RuleFor(c => c.Bytes).NotEmpty();
            RuleFor(c => c.FileName).NotEmpty();
        }
    }
}
