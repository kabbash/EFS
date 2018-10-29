using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Utilities;

namespace Trainer.Controllers
{
    [Route("")]      
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public ActionResult GetStatusCodeResult(ResultMessage resultMessage)
        {
            var x = HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Role);
            return StatusCode((int)resultMessage.Status, resultMessage);
        }
    }
}