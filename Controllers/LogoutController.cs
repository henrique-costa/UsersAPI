using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UsersAPI.Services;

namespace UsersAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private LogoutService _logoutService;

        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult LogoutUser()
        {
            Result result = _logoutService.LogoutUser();

            if (result.IsFailed) 
            {
                return Unauthorized(result.Errors.FirstOrDefault());
            }

            return Ok(result.Successes);
        }
    }
}
