using OTraining.Core.Models;
using Shared.Core.Utilities.Models;

namespace OTraining.Core.Interfaces
{
    public interface IOTrainingManager
    {
        ResultMessage GetAll();
        ResultMessage UpdateDetails(OTrainingDetailsDto detailsDto);
        ResultMessage InsertProgram(OTrainingProgramDto programDto, IUserDto user);
        ResultMessage GetProgramById(int id);
        ResultMessage UpdateProgram(OTrainingProgramDto programDto, int id, IUserDto user);
        ResultMessage DeleteProgram(int id, IUserDto user);
    }
}
