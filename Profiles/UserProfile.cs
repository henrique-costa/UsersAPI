using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsersAPI.Data.DTO;
using UsersAPI.Model;

namespace UsersAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, UserModel>();
            CreateMap<UserModel, IdentityUser<int>>();
        }
    }
}
