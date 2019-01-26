using Shared.Core.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Core.Models
{
    public partial class ProgramsImages : IImageBase
    {
        public int Id { get; set; }
        [Required]
        public string Path { get; set; }
        [ForeignKey("Program")]
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual TrainersPrograms Program { get; set; }
    }
}
