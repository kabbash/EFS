using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OTraining.Core.Interfaces;
using OTraining.Core.Models;

namespace Trainer.Controllers
{
    [Route("api/OTraining")]
    [ApiController]
    public class OTrainingApiController : BaseController
    {
        private readonly IOTrainingManager _oTrainingManager;
        public OTrainingApiController(IOTrainingManager oTrainingManager)
        {
            _oTrainingManager = oTrainingManager;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return GetStatusCodeResult(_oTrainingManager.GetAll());
        }

        [HttpGet("getprogram/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetProgram(int id)
        {
            return GetStatusCodeResult(_oTrainingManager.GetProgramById(id));
        }

        [HttpPost("AddProgram")]
        [Authorize(Roles = "Admin")]
        public ActionResult Post([FromForm] OTrainingProgramDto programDto)
        {
            return GetStatusCodeResult(_oTrainingManager.InsertProgram(programDto, GetCurrentUser()));
        }

        [HttpPut("updateprogram/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateProgram(int id, [FromForm] OTrainingProgramDto programDto)
        {
            return GetStatusCodeResult(_oTrainingManager.UpdateProgram(programDto, id, GetCurrentUser()));
        }

        [HttpPut("updatedetails")]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateDetails([FromForm] OTrainingDetailsDto programDto)
        {
            return GetStatusCodeResult(_oTrainingManager.UpdateDetails(programDto));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return GetStatusCodeResult(_oTrainingManager.DeleteProgram(id, GetCurrentUser()));
        }
    }
}