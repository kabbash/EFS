using System;
using System.Collections.Generic;
using System.Text;

namespace Attachments.Core.Models
{
    public class SaveFileDto
    {
        public string TempName { get; set; }
        public string NewPath { get; set; }
        public string SavedName { get; set; }
    }
}
