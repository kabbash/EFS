using Authentication.Interfaces;
using Authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trainer.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
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
            var result = _userService.Register(userData);
            switch (result.Status)
            {
                case (int) ResultStatus.InvalidData:
                    return BadRequest(result);

                case (int)ResultStatus.Error:
                    return StatusCode(500, result);

                case (int)ResultStatus.Success:
                    return Ok(result);
            }
            return StatusCode(500 , result);
        }

        [HttpGet]
        [Route("VerifyEmail")]
        public IActionResult VerifyEmail([FromQuery]string activationToken)
        {
            var result = _userService.VerifyEmail(activationToken);
            switch (result.Status)
            {
                case (int)ResultStatus.InvalidData:
                    return BadRequest(result);

                case (int)ResultStatus.Error:
                    return StatusCode(500, result);

                case (int)ResultStatus.Success:
                    return Ok(result);
            }
            return StatusCode(500, result);
        }

    }
}
