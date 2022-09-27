﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsersAPI.Data.Requests
{
    public class DoPasswordRequest
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RepeatPassword { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
