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
    }
}
