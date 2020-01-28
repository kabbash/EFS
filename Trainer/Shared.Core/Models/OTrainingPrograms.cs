using Shared.Core.Models.Base;
using System;

namespace Shared.Core.Models
{
    public class OTrainingPrograms : IBaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string Name { get; set; }
        public string Features { get; set; }
        public string ProfilePicture { get; set; }
    }
}
