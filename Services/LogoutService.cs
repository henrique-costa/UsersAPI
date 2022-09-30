using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsersAPI.Model;

namespace UsersAPI.Services
{
    public class LogoutService
    {
        private SignInManager<CustomIdentityUser> _signInManager;

        public LogoutService(SignInManager<CustomIdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result LogoutUser()
        {
            var result = _signInManager.SignOutAsync();
            if (result.IsCompletedSuccessfully)
            {
                return Result.Ok();
            }
            return Result.Fail("Logout Failed");
        }
    }
}
