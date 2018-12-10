using Attachments.Core.Models;
using FluentValidation;
using Microsoft.Extensions.Options;
using Shared.Core.Resources;

namespace Attachments.Core.Validators
{
    public class UploadFileDtoValidator : AbstractValidator<UploadFileDto>
    {
        private readonly IOptions<AttachmentsResources> _attachmentsResources;
        public UploadFileDtoValidator(IOptions<AttachmentsResources> attachmentsResources)
        {
            _attachmentsResources = attachmentsResources;
            RuleFor(c => c.Bytes).NotEmpty();
            RuleFor(c => c.FileName).NotEmpty();
        }
    }
}
