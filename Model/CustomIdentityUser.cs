using Microsoft.AspNetCore.Identity;
using System;

namespace UsersAPI.Model
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public DateTime DateOfBirth { get; set; }
    }
}
