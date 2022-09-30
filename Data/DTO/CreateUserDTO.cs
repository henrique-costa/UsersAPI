using System;
using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Data.DTO
{
    public class CreateUserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }

}
