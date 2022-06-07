using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace UsersAPI.Services
{
    public class LogoutService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LogoutService(SignInManager<IdentityUser<int>> signInManager)
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
