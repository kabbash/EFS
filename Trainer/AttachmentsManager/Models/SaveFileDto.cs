using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attachments.Core.Models
{
    public class SaveFileDto
    {
        public string FileName { get; set; }
        public AttachmentTypesEnum attachmentType { get; set; }
        public string SubFolderName { get; set; }
        public string TempPath { get; set; }
    }
}
