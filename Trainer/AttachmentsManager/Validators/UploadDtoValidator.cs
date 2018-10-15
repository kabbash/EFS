using Attachments.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
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
            RuleFor(c => c.Bytes).NotEmpty().WithMessage(attachmentsResources.Value.UploadFileBytesEmptyValidation);
            RuleFor(c => c.Name).NotEmpty().WithMessage(attachmentsResources.Value.UploadFileNameEmptyValidation);
        }
    }
}
