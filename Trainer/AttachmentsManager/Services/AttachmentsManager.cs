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
            uploadTempPath = _attachmentsResources.Value.TempPath;
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
                string filefullPath = Path.Combine( rootPath , uploadTempPath, file.FileName);

                //var x = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                //var z = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath);


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
                    ErrorCode = ErrorsCodeEnum.AttachmentsUploadError,
                    Status = HttpStatusCode.InternalServerError
                };
            }
        }
        public bool Save(SaveFileDto file)
        {
            try
            {
                var rootPath = System.IO.Directory.GetCurrentDirectory();
                var saveFolder = GetAttachmentTypePath(file.attachmentType);
                Directory.CreateDirectory(Path.Combine(rootPath, saveFolder, file.SubFolderName ?? ""));
                var fileDestinationPath = Path.Combine(rootPath, saveFolder, file.SubFolderName ?? "", file.FileName);
                if (File.Exists(file.TempPath))
                {
                    File.Move(file.TempPath , fileDestinationPath);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private string GetAttachmentTypePath(AttachmentTypesEnum type)
        {
            switch (type)
            {
                case AttachmentTypesEnum.Product:
                    return _attachmentsResources.Value.ProductsFolder;
                case AttachmentTypesEnum.Category:
                    return _attachmentsResources.Value.CategoriesFolder;
                case AttachmentTypesEnum.SubCategory:
                    return _attachmentsResources.Value.SubCategoriesFolder;
                default:
                    return string.Empty;
            }
        }

    }
}
