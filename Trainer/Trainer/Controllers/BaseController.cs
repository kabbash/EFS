using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Trainer.Controllers
{
    [Route("")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected UserDto GetCurrentUser()
        {
            return new UserDto()
            {
                Id = CurrentUserId(),
                IsAdmin = IsAdmin()
            };
        }


        [NonAction]
        public ActionResult GetStatusCodeResult(ResultMessage resultMessage)
        {
            var x = HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Role);
            return StatusCode((int)resultMessage.Status, resultMessage);
        }
        private string CurrentUserId()
        {
            return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
        }
        private List<string> CurrentUserRoles()
        {
            return User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
        }
        private bool IsAdmin()
        {
            return User.Claims.Where(c => c.Type == ClaimTypes.Role).Any(c => c.Value == UserRoles.Admin.ToString());
        }
    }
}