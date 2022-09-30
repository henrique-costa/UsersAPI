using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UsersAPI.Data.DTO;
using UsersAPI.Data.Requests;
using UsersAPI.Services;

namespace UsersAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private RegistrationService _registrationService;

        public RegistrationController(RegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public IActionResult RegisterUser(CreateUserDTO createDto)
        {
            Result result = _registrationService.RegisterUser(createDto);
            if (result.IsFailed) 
            {
                return StatusCode(500);
            }
            return Ok(result.Successes.FirstOrDefault());
        }


        [HttpGet("/ativa")]
        public IActionResult ActivateUserAccount([FromQuery] ActivateAccountRequest request)
        {
            Result result = _registrationService.ActivateUserAccount(request);
            if (result.IsFailed)
            {
                return StatusCode(500);
            }
            return Ok(result.Successes.FirstOrDefault());
        }
    }
}
