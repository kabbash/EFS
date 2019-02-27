using Attachments.Core.Interfaces;
using Attachments.Core.Models;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Shared.Core.Resources;
using Shared.Core.Utilities.Enums;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Attachments.Core.Services
{
    public class AttachmentsManager : IAttachmentsManager
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IOptions<AttachmentsResources> _attachmentsResources;
        private readonly IValidator<UploadFileDto> _validator;

        public AttachmentsManager(IOptions<AttachmentsResources> attachmentsResources, IValidator<UploadFileDto> validator, IHostingEnvironment environment)
        {
            _attachmentsResources = attachmentsResources;
            _validator = validator;
            _hostingEnvironment = environment;
        }

        /// <summary>
        ///   Save file and return its relative path
        /// </summary>
        /// <param name="fileDto"></param>
        /// <returns> relative path of file </returns>
        public string Save(SavedFileDto fileDto)
        {
            try
            {

                var rootPath = _hostingEnvironment.WebRootPath;

                var fileName = fileDto.CanChangeName ? $"{Guid.NewGuid()}{Path.GetExtension(fileDto.File.ContentType)}" : fileDto.File.Name;

                var attachmentPath = Path.Combine(GetAttachmentTypePath(fileDto.attachmentType), fileDto.SubFolderName ?? "");
                var relativeFilePath = Path.Combine(attachmentPath, fileName);
                Directory.CreateDirectory(Path.Combine(rootPath, attachmentPath));
                var fileDestinationPath = Path.Combine(rootPath, relativeFilePath);

                using (var fileStream = new FileStream(fileDestinationPath, FileMode.Create))
                {
                    fileDto.File.CopyTo(fileStream);
                }

                return getRelativeURL(relativeFilePath);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        /// <summary>
        ///   Save file Async and return its relative path
        /// </summary>
        /// <param name="fileDto"></param>
        /// <returns> relative path of file </returns>
        public async Task<string> SaveAsync(SavedFileDto fileDto)
        {
            try
            {
                var rootPath = _hostingEnvironment.WebRootPath;

                var fileName = fileDto.CanChangeName ? $"{Guid.NewGuid()}.{Path.GetExtension(fileDto.File.Name)}" : fileDto.File.Name;

                var attachmentPath = Path.Combine(GetAttachmentTypePath(fileDto.attachmentType), fileDto.SubFolderName ?? "");
                var relativeFilePath = Path.Combine(attachmentPath, fileName);

               // Directory.CreateDirectory(Path.Combine(rootPath, attachmentPath));
                var fileDestinationPath = Path.Combine(rootPath, relativeFilePath);

                using (var fileStream = new FileStream(fileDestinationPath, FileMode.Create))
                {
                    await fileDto.File.CopyToAsync(fileStream);
                }

                return getRelativeURL(relativeFilePath);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public bool Delete(string filePath)
        {
            try
            {
                var rootPath = _hostingEnvironment.WebRootPath;
                filePath = Path.Combine(rootPath, filePath);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);

                    var folderPath = Path.GetDirectoryName(filePath);
                    if (Directory.GetFiles(folderPath).Length == 0)
                        Directory.Delete(folderPath);

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //log error
                return false;
            }
        }

        private string getRelativeURL(string relativeFilePath)
        {
            return Uri.EscapeUriString(relativeFilePath.Replace(@"\", "/"));
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
                case AttachmentTypesEnum.Banners:
                    return _attachmentsResources.Value.BannersFolder;
                default:
                    throw new NotImplementedException();
            }
        }

        public bool DeleteFolder(string folderName, AttachmentTypesEnum attachmentType)
        {
            try
            {
                folderName = Path.Combine(_hostingEnvironment.WebRootPath, GetAttachmentTypePath(attachmentType), folderName);

                if (Directory.Exists(folderName))
                {
                    Directory.Delete(folderName, true);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //log error
                return false;
            }
        }
    }
}
