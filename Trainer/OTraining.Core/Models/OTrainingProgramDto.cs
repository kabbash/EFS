using Microsoft.AspNetCore.Http;

namespace OTraining.Core.Models
{
    public class OTrainingProgramDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Features { get; set; }
        public string ProfilePicture { get; set; }
        public IFormFile ProfilePictureFile { get; set; }
    }
}
