using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.DTO;
using UsersAPI.Services;

namespace UsersAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private RegistrationService _RegistrationService;

        public RegistrationController(RegistrationService registrationService)
        {
            _RegistrationService = registrationService;
        }

        [HttpPost]
        public IActionResult RegisterUser(CreateUserDTO createDto)
        {
            Result result = _RegistrationService.RegisterUser(createDto);
            if (result.IsFailed) 
            {
                return StatusCode(500);
            }
            return Ok();
        }
    }
}
