using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UsersAPI.Data.DTO;
using UsersAPI.Data.Requests;
using UsersAPI.Model;

namespace UsersAPI.Services
{
    public class RegistrationService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private EmailService _emailService;
        private RoleManager<IdentityRole<int>> _roleManager;

        public RegistrationService(IMapper mapper,
            UserManager<IdentityUser<int>> userManager,
            EmailService emailService, RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            _roleManager = roleManager;
        }

        public Result RegisterUserAsync(CreateUserDTO createDto)
        {
            UserModel user = _mapper.Map<UserModel>(createDto);

            IdentityUser<int> identityUser = _mapper.Map<IdentityUser<int>>(user);
            
            var resultIdentity = _userManager.CreateAsync(identityUser, createDto.Password).Result;

            var createRoleResult = _roleManager.CreateAsync(new IdentityRole<int>("admin")).Result;

            var userRoleResult =  _userManager.AddToRoleAsync(identityUser, "admin").Result;

            if (resultIdentity.Succeeded)
            {
                string code = _userManager.GenerateEmailConfirmationTokenAsync(identityUser).Result;
                var encodedCode = HttpUtility.UrlEncode(code);
                _emailService.SendEmail(new[] { identityUser.Email }, "Activation Link", identityUser.Id, encodedCode);
                return Result.Ok().WithSuccess(code);
            }

            return Result.Fail($"Fail to register User + {resultIdentity.Errors.FirstOrDefault()}");
        }

        public Result ActivateUserAccount(ActivateAccountRequest request)
        {
            var identityUser = _userManager.Users.FirstOrDefault(user => user.Id == request.UserId);

            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.ActivationCode).Result;

            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Fail to activate user account");
        }
    }
}
