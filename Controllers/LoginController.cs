using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UsersAPI.Data.Requests;
using UsersAPI.Services;

namespace UsersAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LoginUser(LoginRequest request)
        {
            Result result = _loginService.LoginUser(request);
            if (result.IsFailed)
            {
                return Unauthorized(result.Errors.FirstOrDefault());
            }

            return Ok(result.Successes.FirstOrDefault());
        }


        [HttpPost("/password-reset")]
        public IActionResult PasswordResetRequest(PasswordRequest request)
        {
            Result result = _loginService.PasswordResetRequest(request);
            if (result.IsFailed)
            {
                return Unauthorized(result.Errors);
            }
            return Ok(result.Successes.FirstOrDefault());
        }

        [HttpPost("/do-password-reset")]
        public IActionResult PasswordReset(DoPasswordRequest request)
        {
            Result result = _loginService.PasswordReset(request);
            if (result.IsFailed)
            {
                return Unauthorized(result.Errors);
            }
            return Ok(result.Successes.FirstOrDefault());
        }

    }
}
