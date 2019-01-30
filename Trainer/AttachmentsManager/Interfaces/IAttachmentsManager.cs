using Attachments.Core.Models;
using Shared.Core.Utilities.Enums;
using System.Threading.Tasks;

namespace Attachments.Core.Interfaces
{
    public interface IAttachmentsManager
    {
        string Save(SavedFileDto savedFile);
        Task<string> SaveAsync(SavedFileDto savedFile);
        bool Delete(string filePath);
        bool DeleteFolder(string filePath, AttachmentTypesEnum attachmentType);
    }
}
