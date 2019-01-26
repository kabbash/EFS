using Shared.Core.Utilities.Enums;
using System.Collections.Generic;

namespace Attachments.Core.Models
{
    public class SliderDto
    {
        public int ParentId { get; set; }
        public AttachmentTypesEnum attachmentType { get; set; }
        public string SubFolderName { get; set; }
        public List<SliderItemDto> Items { get; set; }
    }
}
