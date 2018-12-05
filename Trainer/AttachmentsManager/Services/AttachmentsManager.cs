using Attachments.Core.Interfaces;
using Attachments.Core.Models;
using Shared.Core.Resources;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Options;
using FluentValidation;
using System.Net;

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
            uploadTempPath = _attachmentsResources.Value.TempFolder;
            _validator = validator;
        }
        public ResultMessage Upload(UploadFileDto file)
        {
            var validationResult = _validator.Validate(file);
            if (!validationResult.IsValid)
                return new ResultMessage
                {
                    Status = HttpStatusCode.BadRequest,
                    ValidationMessages = validationResult.GetErrorsList()
                };

            try
            {

                var rootPath = System.IO.Directory.GetCurrentDirectory();
                Directory.CreateDirectory(Path.Combine(rootPath, uploadTempPath));
                string filefullPath = Path.Combine(rootPath, uploadTempPath, file.FileName);


                if (File.Exists(filefullPath))
                    File.Delete(filefullPath);

                FileStream fileStream = new FileStream(filefullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                using (System.IO.FileStream fs = fileStream)
                {
                    fs.Write(file.Bytes, 0, file.Bytes.Length);
                }
                return new ResultMessage()
                {
                    Data = filefullPath,
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                //log ex error in file
                return new ResultMessage()
                {
                    ErrorCode = (int)AttachmentsErrorsCodeEnum.AttachmentsUploadError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public string Save(SaveFileDto file)
        {
            try
            {
                var rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                var saveFolder = GetAttachmentTypePath(file.attachmentType);
                var fileExtension = file.TempPath.Split('.').Last();
                var newFileName = $"{Guid.NewGuid()}.{fileExtension}";

                var relativeFilePath = Path.Combine(saveFolder, file.SubFolderName ?? "", newFileName);

                Directory.CreateDirectory(Path.Combine(rootPath, saveFolder, file.SubFolderName ?? ""));
                var fileDestinationPath = Path.Combine(rootPath, relativeFilePath);

                if (File.Exists(file.TempPath))
                {
                    File.Move(file.TempPath, fileDestinationPath);
                    return getRelativeURL(relativeFilePath);
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        private string getRelativeURL(string relativeFilePath)
        {
            return relativeFilePath.Replace(@"\", "/");
        }

        private string GetAttachmentTypePath(AttachmentTypesEnum type)
        {
            switch (type)
            {
                case AttachmentTypesEnum.Products_Categories:
                    return _attachmentsResources.Value.ProductsCategoriesFolder;
                case AttachmentTypesEnum.Products:
                    return _attachmentsResources.Value.ProductsFolder;
                case AttachmentTypesEnum.Articles_Categories:
                    return _attachmentsResources.Value.ArticlesCategoriesFolder;
                case AttachmentTypesEnum.Articles:
                    return _attachmentsResources.Value.ArticlesFolder;
                case AttachmentTypesEnum.Temp:
                    return _attachmentsResources.Value.TempFolder;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
