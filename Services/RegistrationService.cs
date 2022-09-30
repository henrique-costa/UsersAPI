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
        private UserManager<CustomIdentityUser> _userManager;
        private EmailService _emailService;

        public RegistrationService(IMapper mapper,
            UserManager<CustomIdentityUser> userManager,
            EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public Result RegisterUser(CreateUserDTO createDto)
        {
            UserModel user = _mapper.Map<UserModel>(createDto);

            CustomIdentityUser identityUser = _mapper.Map<CustomIdentityUser>(user);

            IdentityResult identityResult = _userManager.CreateAsync(identityUser, createDto.Password).Result;

             _userManager.AddToRoleAsync(identityUser, "regular");            

            if (identityResult.Succeeded)
            {
                string code = _userManager.GenerateEmailConfirmationTokenAsync(identityUser).Result;
                var encodedCode = HttpUtility.UrlEncode(code);
                _emailService.SendEmail(new[] { identityUser.Email }, "Activation Link", identityUser.Id, encodedCode);
                return Result.Ok().WithSuccess(code);
            }

            return Result.Fail($"Fail to register User + {identityResult.Errors.FirstOrDefault()}");
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
