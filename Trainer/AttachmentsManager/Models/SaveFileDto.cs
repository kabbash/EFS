using Microsoft.AspNetCore.Http;
using Shared.Core.Utilities;

namespace Attachments.Core.Models
{
    public class SavedFileDto
    {
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public AttachmentTypesEnum attachmentType { get; set; }
        public string SubFolderName { get; set; }
        public bool CanChangeName { get; set; }
    }
}
