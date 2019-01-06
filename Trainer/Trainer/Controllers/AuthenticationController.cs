using Authentication.Interfaces;
using Authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Trainer.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : BaseController
    {
        protected IUserService _userService;
        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("AddRoleToUser")]
        public IActionResult AddRoleToUser([FromBody] AddRoleToUserDto data)
        {
            var result = _userService.AddRoleToUser(data);
            if (result)
                return Ok();
            else
                return BadRequest();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("AddRole")]
        public IActionResult AddRole([FromBody] RoleDto data)
        {
            var result = _userService.AddRole(data);
            if (result)
                return Ok();
            else
                return BadRequest();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("DeleteRole/{roleName}")]
        public IActionResult DeleteRole(string roleName)
        {
            var result = _userService.DeleteRole(roleName);
            if (result)
                return Ok();
            else
                return BadRequest();

        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] RegisterDto userData)
        {
            return GetStatusCodeResult(_userService.Register(userData));
        }

        [HttpGet]
        [Route("VerifyEmail")]
        public IActionResult VerifyEmail([FromQuery]string activationToken)
        {
            return GetStatusCodeResult(_userService.VerifyEmail(activationToken));
        }

        [HttpPost]
        [Route("ResetPassword")]
        public IActionResult ResetPassword([FromBody]ResetPasswordDto data)
        {
            return GetStatusCodeResult(_userService.ResetPassword(data));
        }

        [HttpPost]
        [Route("SetResetedPassword")]
        public IActionResult SetResetedPassword([FromBody]SetPasswordDto data)
        {
            return GetStatusCodeResult(_userService.SetResetedPassword(data));
        }

        [HttpPost]
        [Route("ChangePassword")]
        [Authorize]
        public IActionResult ChangePassword([FromBody]ChanePasswordDto data)
        {
            data.UserId = User.Identity.Name;
            return GetStatusCodeResult(_userService.ChangePassword(data));
        }

    }
}
