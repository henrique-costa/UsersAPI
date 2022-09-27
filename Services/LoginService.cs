using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using UsersAPI.Data.Requests;
using UsersAPI.Model;

namespace UsersAPI.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;
        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LoginUser(LoginRequest request)
        {
            var resultIdentity = _signInManager
                .PasswordSignInAsync(request.UserName, request.Password, false, false);

            if (resultIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(x => x.NormalizedUserName == request.UserName.ToUpper());

                Token token = _tokenService.CreateToken(identityUser, _signInManager.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());
                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Login failed");
        }

        
        public Result PasswordResetRequest(PasswordRequest request)
        {
            IdentityUser<int> identityUser = GetUserByEmail(request.Email);

            if (identityUser != null)
            {
                string recoveryCode = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(recoveryCode);
            }

            return Result.Fail("Fail to get recovery services");
        }       

        public Result PasswordReset(DoPasswordRequest request)
        {
            IdentityUser<int> identityUser = GetUserByEmail(request.Email);

            IdentityResult identityResult = _signInManager.UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password).Result;

            if (identityResult.Succeeded) 
            {
                return Result.Ok().WithSuccess("Password reset successfully");
            }

            return Result.Fail("There was a error resetting password.");
        }


        private IdentityUser<int> GetUserByEmail(string email)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(x => x.NormalizedEmail == email.ToUpper());
        }
    }
}
