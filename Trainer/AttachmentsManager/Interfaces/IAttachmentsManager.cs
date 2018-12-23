using Attachments.Core.Models;
using System.Threading.Tasks;

namespace Attachments.Core.Interfaces
{
    public interface IAttachmentsManager
    {
        string Save(SavedFileDto savedFile);
        Task<string> SaveAsync(SavedFileDto savedFile);
        bool Delete(string filePath);
    }
}
