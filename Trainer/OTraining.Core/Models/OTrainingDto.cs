using System;
using System.Collections.Generic;
using System.Text;

namespace OTraining.Core.Models
{
    public class OTrainingDto
    {
        public OTrainingDto()
        {
            ProgramsDto = new HashSet<OTrainingProgramDto>();
            DetailsDto = new OTrainingDetailsDto();
        }
        public OTrainingDetailsDto DetailsDto { get; set; }
        public IEnumerable<OTrainingProgramDto> ProgramsDto { get; set; }
    }
}
