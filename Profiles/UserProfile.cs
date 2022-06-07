using AutoMapper;
using UsersAPI.Data.DTO;
using UsersAPI.Model;

namespace UsersAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, UserModel>();
        }
    }
}
