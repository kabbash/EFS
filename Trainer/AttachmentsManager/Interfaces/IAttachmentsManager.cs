using Attachments.Core.Models;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attachments.Core.Interfaces
{
    public interface IAttachmentsManager
    {
        ResultMessage Upload(UploadFileDto uploadedFile);
        bool Save(SaveFileDto savedFile);
    }
}
