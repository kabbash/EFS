using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Utilities;

namespace Trainer.Controllers
{       
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public ActionResult GetStatusCodeResult(ResultMessage resultMessage)
        {
            return StatusCode((int)resultMessage.Status, resultMessage);
        }
    }
}