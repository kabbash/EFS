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
            return GetStatusCodeResult(_userService.Authenticate(userParam.Username, userParam.Password));
        }
        [AllowAnonymous]
        [HttpPost("loginFb")]
        public IActionResult AuthenticateFb([FromBody] FacebookLoginDto user)
        {
            return GetStatusCodeResult(_userService.RegisterFBUser(user));
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll([FromQuery] UsersFilter usersFilter)
        {
            var users = _userService.GetAll(usersFilter);
            return GetStatusCodeResult(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("AddRoleToUser")]
        public IActionResult AddRoleToUser([FromBody] UserRoleDto data)
        {
            var result = _userService.AddRoleToUser(data);
            return GetStatusCodeResult(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("RemoveRoleFromUser")]
        public IActionResult RemoveRoleFromUser([FromBody] UserRoleDto data)
        {
            var result = _userService.RemoveRoleFromUser(data);
            return GetStatusCodeResult(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("UpdateUserAccess")]
        public IActionResult UpdateUserAccess([FromBody] UserAccessDto data)
        {
            var result = _userService.UpdateUserAccess(data);
            return GetStatusCodeResult(result);
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
