using Attachments.Core.Interfaces;
using Attachments.Core.Models;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shared.Core.Settings;
using Shared.Core.Utilities.Enums;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Attachments.Core.Services
{
    public class AttachmentsManager : IAttachmentsManager
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly AppSettings _settings;
        private readonly IValidator<UploadFileDto> _validator;
        private readonly ILogger<AttachmentsManager> _logger;


        public AttachmentsManager(IOptions<AppSettings> settings, IValidator<UploadFileDto> validator, IHostingEnvironment environment, ILogger<AttachmentsManager> logger)
        {
            _settings = settings.Value;
            _validator = validator;
            _hostingEnvironment = environment;
            _logger = logger;
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
                var fileExtension = Path.GetExtension(fileDto.File.ContentType);
                fileExtension = string.IsNullOrEmpty(fileExtension) ? ".png" : fileExtension;
                var fileName = fileDto.CanChangeName ? $"{Guid.NewGuid()}{fileExtension}" : fileDto.File.Name;

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
                _logger.LogError(ex, string.Empty);
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
                _logger.LogError(ex, string.Empty);
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
                _logger.LogError(ex, string.Empty);
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
                    return _settings.AppPathsSettings.Attachments.ProductsCategoriesFolder;
                case AttachmentTypesEnum.Products:
                    return _settings.AppPathsSettings.Attachments.ProductsFolder;
                case AttachmentTypesEnum.Articles_Categories:
                    return _settings.AppPathsSettings.Attachments.ArticlesCategoriesFolder;
                case AttachmentTypesEnum.Articles:
                    return _settings.AppPathsSettings.Attachments.ArticlesFolder;
                case AttachmentTypesEnum.Banners:
                    return _settings.AppPathsSettings.Attachments.BannersFolder;
                case AttachmentTypesEnum.OTrainingProgram:
                    return _settings.AppPathsSettings.Attachments.OTrainingFolder;
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
                _logger.LogError(ex, string.Empty);
                return false;
            }
        }
    }
}
