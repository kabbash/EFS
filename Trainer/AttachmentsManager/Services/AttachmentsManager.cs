using Attachments.Core.Interfaces;
using Attachments.Core.Models;
using Shared.Core.Resources;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Options;
using FluentValidation;

namespace Attachments.Core.Services
{
    public class AttachmentsManager : IAttachmentsManager
    {
        private readonly IOptions<AttachmentsResources> _attachmentsResources;
        private readonly string uploadTempPath;
        private readonly IValidator<UploadFileDto> _validator;

        public AttachmentsManager(IOptions<AttachmentsResources> attachmentsResources, IValidator<UploadFileDto> validator)
        {
            _attachmentsResources = attachmentsResources;
            uploadTempPath = _attachmentsResources.Value.TempPath;
            _validator = validator;
        }
        public ResultMessage Upload(UploadFileDto file)
        {
            var validationResult = _validator.Validate(file);
            if (!validationResult.IsValid)
            {
                List<string> errors = new List<string>();
                foreach (var error in validationResult.Errors)
                    errors.Add(error.ErrorMessage);

                return new ResultMessage
                {
                    Status = (int)ResultStatus.Validation,
                    ValidationMessages = errors
                };
            }

            try
            {
                string fullPath = Path.Combine(uploadTempPath, file.Name);

                if (File.Exists(fullPath))
                    File.Delete(fullPath);

                FileStream fileStream = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                using (System.IO.FileStream fs = fileStream)
                {
                    fs.Write(file.Bytes, 0, file.Bytes.Length);
                }
                return new ResultMessage()
                {
                    Data = fullPath,
                    Message = _attachmentsResources.Value.UploadErrorMsg,
                    Status = (int)ResultStatus.Success
                };
            }
            catch (Exception ex)
            {
                //log ex error in file
                return new ResultMessage()
                {
                    Message = _attachmentsResources.Value.UploadErrorMsg,
                    Status = (int)ResultStatus.Error
                };
            }
        }
        public bool Move(SaveFileDto file)
        {
            try
            {                
                Directory.CreateDirectory(file.NewPath);

                var fileDestinationPath = Path.Combine(file.NewPath, file.SavedName);
                var tempFilePath = Path.Combine(_attachmentsResources.Value.TempPath, file.TempName);
                if (File.Exists(file.TempName))
                {
                    File.Move(tempFilePath , fileDestinationPath);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
