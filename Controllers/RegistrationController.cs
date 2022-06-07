using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.DTO;

namespace UsersAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        public RegistrationController()
        {

        }

        public IActionResult RegisterUser(CreateUserDTO createDto)
        {
            return Ok();
        }
    }
}
