using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attachments.Core.Interfaces
{
    public interface IAttachmentsManager
    {
        ResultMessage Upload(byte[] file, string fileName);
    }
}
