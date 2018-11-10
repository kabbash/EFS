using System;
using System.Collections.Generic;
using System.Text;

namespace Attachments.Core.Models
{
    public class UploadFileDto
    {
        public byte[] Bytes { get; set; }
        public string FileName { get; set; }
    }
}
