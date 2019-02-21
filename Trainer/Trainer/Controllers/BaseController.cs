using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Utilities.Models;
using System.Linq;
using System.Security.Claims;

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

        protected string CurrentUserId
        {
            get
            {
                return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            }
        }
    }
}