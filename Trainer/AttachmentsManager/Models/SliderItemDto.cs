using Microsoft.AspNetCore.Http;

namespace Attachments.Core.Models
{
    public class SliderItemDto
    {
        public int Id { get; set; }
        public IFormFile File { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsNew { get; set; }
        public bool IsDataUpdated { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsProfilePicture { get; set; }
        public bool IsProfilePictureUpdated { get; set; }
    }
}
