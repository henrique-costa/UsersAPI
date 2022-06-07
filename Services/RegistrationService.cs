using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using UsersAPI.Data.DTO;
using UsersAPI.Model;

namespace UsersAPI.Services
{
    public class RegistrationService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        public RegistrationService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result RegisterUser(CreateUserDTO createDto)
        {
            UserModel user = _mapper.Map<UserModel>(createDto);
            IdentityUser<int> identityUser = _mapper.Map<IdentityUser<int>>(user);
            Task<IdentityResult> resultIdentity = _userManager
                .CreateAsync(identityUser, createDto.Password);

            if (resultIdentity.Result.Succeeded)
            {
                string code = _userManager.GenerateEmailConfirmationTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(code);
            }

            return Result.Fail("Fail to register User");
        }
    }
}
