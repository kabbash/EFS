using Attachments.Core.Models;
using FluentValidation;
using Shared.Core.Utilities.Enums;

namespace Attachments.Core.Validators
{
    public class UploadFileDtoValidator : AbstractValidator<UploadFileDto>
    {
        public UploadFileDtoValidator()
        {
            RuleFor(c => c.Bytes).NotEmpty().WithMessage(((int)AttachmentsErrorsCodeEnum.ValidationFileEmpty).ToString());
            RuleFor(c => c.FileName).NotEmpty().WithMessage(((int)AttachmentsErrorsCodeEnum.ValidationFileNameRequired).ToString());
        }
    }
}
